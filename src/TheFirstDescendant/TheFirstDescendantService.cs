using TheFirstDescendant.Models;

namespace TheFirstDescendant;

/// <summary>
/// This is the default service class for accessing The First Descendant API.
/// The default language code is set to English (en).
/// </summary>
public class TheFirstDescendantService
{
    private readonly TheFirstDescendantApiClient _client;
    private const LanguageCode DefaultLanguageCode = LanguageCode.En;

    public TheFirstDescendantService(HttpClient httpClient)
    {
        _client = new TheFirstDescendantApiClient(httpClient);
    }

    public async Task<ICollection<Descendant>> GetDescendantsAsync(CancellationToken cancellationToken = default)
    {
        return await _client.GetDescendantsAsync(DefaultLanguageCode, cancellationToken);
    }

    public async Task<ICollection<Weapon>> GetWeaponsAsync(CancellationToken cancellationToken = default)
    {
        return await _client.GetWeaponsAsync(DefaultLanguageCode, cancellationToken);
    }

    public async Task<ICollection<Module>> GetModulesAsync(CancellationToken cancellationToken = default)
    {
        return await _client.GetModulesAsync(DefaultLanguageCode, cancellationToken);
    }

    public async Task<ICollection<Reactor>> GetReactorsAsync(CancellationToken cancellationToken = default)
    {
        return await _client.GetReactorsAsync(DefaultLanguageCode, cancellationToken);
    }

    public async Task<ICollection<ExternalComponent>> GetExternalComponentsAsync(CancellationToken cancellationToken = default)
    {
        return await _client.GetExternalComponentsAsync(DefaultLanguageCode, cancellationToken);
    }

    public async Task<ICollection<DifficultyLevelReward>> GetRewardsAsync(CancellationToken cancellationToken = default)
    {
        return await _client.GetRewardsAsync(DefaultLanguageCode, cancellationToken);
    }

    public async Task<ICollection<Stat>> GetStatsAsync(CancellationToken cancellationToken = default)
    {
        return await _client.GetStatsAsync(DefaultLanguageCode, cancellationToken);
    }

    public async Task<ICollection<VoidBattle>> GetVoidBattlesAsync(CancellationToken cancellationToken = default)
    {
        return await _client.GetVoidBattlesAsync(DefaultLanguageCode, cancellationToken);
    }

    public async Task<ICollection<Title>> GetTitlesAsync(CancellationToken cancellationToken = default)
    {
        return await _client.GetTitlesAsync(DefaultLanguageCode, cancellationToken);
    }

    public async Task<ICollection<ConsumableMaterial>> GetConsumableMaterialsAsync(CancellationToken cancellationToken = default)
    {
        return await _client.GetConsumableMaterialsAsync(DefaultLanguageCode, cancellationToken);
    }

    public async Task<ICollection<Research>> GetResearchsAsync(CancellationToken cancellationToken = default)
    {
        return await _client.GetResearchsAsync(DefaultLanguageCode, cancellationToken);
    }

    public async Task<ICollection<AmorphousReward>> GetAmorphousRewardsAsync(CancellationToken cancellationToken = default)
    {
        return await _client.GetAmorphousRewardsAsync(cancellationToken);
    }

    public async Task<ICollection<WeaponType>> GetWeaponTypesAsync(CancellationToken cancellationToken = default)
    {
        return await _client.GetWeaponTypesAsync(DefaultLanguageCode, cancellationToken);
    }

    public async Task<ICollection<Fellow>> GetFellowsAsync(CancellationToken cancellationToken = default)
    {
        return await _client.GetFellowsAsync(DefaultLanguageCode, cancellationToken);
    }

    public async Task<ICollection<Tier>> GetTiersAsync(CancellationToken cancellationToken = default)
    {
        return await _client.GetTiersAsync(DefaultLanguageCode, cancellationToken);
    }

    public async Task<ICollection<CoreSlot>> GetCoreSlotsAsync(CancellationToken cancellationToken = default)
    {
        return await _client.GetCoreSlotsAsync(cancellationToken);
    }

    public async Task<ICollection<CoreType>> GetCoreTypesAsync(CancellationToken cancellationToken = default)
    {
        return await _client.GetCoreTypesAsync(DefaultLanguageCode, cancellationToken);
    }

    public async Task<ICollection<CustomizingItem>> GetCustomizingItemsAsync(CancellationToken cancellationToken = default)
    {
        return await _client.GetCustomizingItemsAsync(DefaultLanguageCode, cancellationToken);
    }

    public async Task<ICollection<Medal>> GetMedalsAsync(CancellationToken cancellationToken = default)
    {
        return await _client.GetMedalsAsync(DefaultLanguageCode, cancellationToken);
    }

    public async Task<ICollection<Vehicle>> GetVehiclesAsync(CancellationToken cancellationToken = default)
    {
        return await _client.GetVehiclesAsync(DefaultLanguageCode, cancellationToken);
    }

    public async Task<ICollection<DescendantLevelDetail>> GetDescendantLevelDetailsAsync(CancellationToken cancellationToken = default)
    {
        return await _client.GetDescendantLevelDetailsAsync(cancellationToken);
    }

    public async Task<ICollection<MasteryRankLevelDetail>> GetMasteryRankLevelDetailsAsync(CancellationToken cancellationToken = default)
    {
        return await _client.GetMasteryRankLevelDetailsAsync(cancellationToken);
    }

    public async Task<ICollection<AmorphousOpenConditionDescription>> GetAmorphousOpenConditionDescriptionsAsync(CancellationToken cancellationToken = default)
    {
        return await _client.GetAmorphousOpenConditionDescriptionsAsync(DefaultLanguageCode, cancellationToken);
    }

    public async Task<ICollection<AcquisitionDetail>> GetAcquisitionDetailsAsync(CancellationToken cancellationToken = default)
    {
        return await _client.GetAcquisitionDetailsAsync(DefaultLanguageCode, cancellationToken);
    }

    public async Task<ICollection<FellowLevelDetail>> GetFellowLevelDetailsAsync(CancellationToken cancellationToken = default)
    {
        return await _client.GetFellowLevelDetailsAsync(cancellationToken);
    }

    public async Task<ICollection<DescendantGroup>> GetDescendantGroupsAsync(CancellationToken cancellationToken = default)
    {
        return await _client.GetDescendantGroupsAsync(DefaultLanguageCode, cancellationToken);
    }

    public async Task<ICollection<AdaptLevel>> GetAdaptLevelsAsync(CancellationToken cancellationToken = default)
    {
        return await _client.GetAdaptLevelsAsync(cancellationToken);
    }

    public async Task<ICollection<ArcheTuningBoardGroup>> GetArcheTuningBoardGroupsAsync(CancellationToken cancellationToken = default)
    {
        return await _client.GetArcheTuningBoardGroupsAsync(cancellationToken);
    }

    public async Task<ICollection<ArcheTuningBoard>> GetArcheTuningBoardsAsync(CancellationToken cancellationToken = default)
    {
        return await _client.GetArcheTuningBoardsAsync(cancellationToken);
    }

    public async Task<ICollection<ArcheTuningNode>> GetArcheTuningNodesAsync(CancellationToken cancellationToken = default)
    {
        return await _client.GetArcheTuningNodesAsync(DefaultLanguageCode, cancellationToken);
    }

    public TheFirstDescendantApiClient GetRawClient()
    {
        return _client;
    }
}