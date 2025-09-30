using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;
using Spectre.Console.Rendering;
using TheFirstDescendant.Models;

namespace TheFirstDescendant.Sample;

public static class DescendantViewer
{
	public static async Task RunAsync()
	{
		var services = new ServiceCollection()
			.AddTheFirstDescendantServices()
			.BuildServiceProvider();

		await using var scope = services.CreateAsyncScope();
		var service = scope.ServiceProvider.GetRequiredService<TheFirstDescendantService>();
		var httpClientFactory = scope.ServiceProvider.GetRequiredService<IHttpClientFactory>();
		var httpClient = httpClientFactory.CreateClient();

		// Display header
		AnsiConsole.Write(
			new FigletText("Descendant Viewer")
				.Centered()
				.Color(Color.Cyan1));

		AnsiConsole.WriteLine();

		// Load descendants and stats
		ICollection<Descendant> descendants;
		ICollection<Stat> stats;
		await AnsiConsole.Status()
			.StartAsync("[yellow]Loading data...[/]", async ctx =>
			{
				descendants = await service.GetDescendantsAsync();
				stats = await service.GetStatsAsync();
			});

		descendants = await service.GetDescendantsAsync();
		stats = await service.GetStatsAsync();

		// Create stat lookup dictionary
		var statLookup = stats.ToDictionary(s => s.StatId, s => s.StatName);

		// Download all images first in parallel
		var imageCache = new Dictionary<string, string>();
		var imageCacheLock = new object();

		await AnsiConsole.Progress()
			.StartAsync(async ctx =>
			{
				var progressTask = ctx.AddTask("[cyan]Downloading images...[/]", maxValue: descendants.Count);

				var downloadTasks = descendants.Select(async descendant =>
				{
					if (!string.IsNullOrEmpty(descendant.DescendantImageUrl))
					{
						try
						{
							var imagePath = Path.Combine(Path.GetTempPath(),
								$"tfd_descendant_{descendant.DescendantId}.png");

							if (!File.Exists(imagePath))
							{
								var imageBytes = await httpClient.GetByteArrayAsync(descendant.DescendantImageUrl);
								await File.WriteAllBytesAsync(imagePath, imageBytes);
							}

							lock (imageCacheLock)
							{
								imageCache[descendant.DescendantId] = imagePath;
							}
						}
						catch
						{
							// Ignore download failures
						}
					}

					progressTask.Increment(1);
				});

				await Task.WhenAll(downloadTasks);
			});

		// Display each descendant
		foreach (var descendant in descendants.OrderBy(d => d.DescendantName))
		{
			DisplayDescendant(descendant, imageCache, statLookup);
			AnsiConsole.WriteLine();
		}
	}

	private static void DisplayDescendant(Descendant descendant, Dictionary<string, string> imageCache, Dictionary<string, string> statLookup)
	{
		// Create a rule with the descendant name
		AnsiConsole.Write(new Rule($"[cyan]{descendant.DescendantName} (ID: {descendant.DescendantId})[/]")
			.RuleStyle(Style.Parse("cyan"))
			.LeftJustified());

		// Create main table to hold image and details side by side
		var mainTable = new Table()
			.Border(TableBorder.None)
			.HideHeaders();
		mainTable.AddColumn(new TableColumn("").Width(50));
		mainTable.AddColumn(new TableColumn(""));

		// Left side: Image
		IRenderable leftPanel;
		if (imageCache.TryGetValue(descendant.DescendantId, out var imagePath))
		{
			try
			{
				var image = new CanvasImage(imagePath).MaxWidth(45);
				leftPanel = new Panel(image)
					.BorderColor(Color.Cyan1)
					.Expand();
			}
			catch
			{
				leftPanel = new Panel(new Text("Image unavailable", new Style(Color.Grey)))
					.BorderColor(Color.Cyan1)
					.Expand();
			}
		}
		else
		{
			leftPanel = new Panel(new Text("No image", new Style(Color.Grey)))
				.BorderColor(Color.Cyan1)
				.Expand();
		}

		// Stats section
		var statsTable = new Table()
			.Border(TableBorder.Rounded)
			.BorderColor(Color.Yellow);
		statsTable.AddColumn("[yellow]Stat[/]");
		statsTable.AddColumn("[yellow]Level 1[/]");

		var maxLevelStat = descendant.DescendantStat.OrderByDescending(s => s.Level).FirstOrDefault();
		if (maxLevelStat != null)
		{
			statsTable.AddColumn($"[yellow]Level {maxLevelStat.Level}[/]");
		}

		var level1Stat = descendant.DescendantStat.OrderBy(s => s.Level).FirstOrDefault();

		if (level1Stat != null && maxLevelStat != null)
		{
			var statNames = level1Stat.StatDetail.Select(s => s.StatId).Distinct().Take(8);

			foreach (var statId in statNames)
			{
				var level1Value = level1Stat.StatDetail.FirstOrDefault(s => s.StatId == statId)?.StatValue ?? 0;
				var maxLevelValue = maxLevelStat.StatDetail.FirstOrDefault(s => s.StatId == statId)?.StatValue ?? 0;

				// Get stat name from lookup, fallback to formatting if not found
				var statName = statLookup.TryGetValue(statId, out var name) ? name : FormatStatName(statId);

				statsTable.AddRow(
					statName,
					level1Value.ToString("N0"),
					maxLevelValue.ToString("N0"));
			}
		}

		// Skills section
		var skillsTable = new Table()
			.Border(TableBorder.Rounded)
			.BorderColor(Color.Magenta1);
		skillsTable.AddColumn("[magenta]Skill[/]");
		skillsTable.AddColumn("[magenta]Type[/]");
		skillsTable.AddColumn("[magenta]Element[/]");
		skillsTable.AddColumn("[magenta]Description[/]");

		foreach (var skill in descendant.DescendantSkill.Take(5))
		{
			var description = skill.SkillDescription;
			if (description.Length > 60)
			{
				description = description.Substring(0, 57) + "...";
			}

			skillsTable.AddRow(
				skill.SkillName,
				skill.SkillType,
				skill.ElementType,
				description);
		}

		// Right side: Stats and Skills stacked
		var rightPanel = new Rows(
			new Panel(statsTable)
				.Header("[yellow]Stats[/]")
				.BorderColor(Color.Yellow),
			new Panel(skillsTable)
				.Header("[magenta]Skills[/]")
				.BorderColor(Color.Magenta1)
		);

		// Add both panels to the main table
		mainTable.AddRow(leftPanel, rightPanel);

		// Display the main table
		AnsiConsole.Write(mainTable);
	}

	private static string FormatStatName(string statId)
	{
		// Format stat IDs into readable names
		return statId switch
		{
			"1" => "HP",
			"2" => "Shield",
			"3" => "DEF",
			"4" => "Shield Recovery",
			"5" => "MP",
			"6" => "MP Recovery",
			"7" => "ATK",
			"8" => "Crit Rate",
			"9" => "Crit Damage",
			_ => statId
		};
	}
}