// This is a blank interface that implements IHoldfastSharedMethods.
// I keep a local copy here so that I don't need to copy and paste it all over the place.

using HoldfastSharedMethods;
using UnityEngine;

public class BlankInterface : IHoldfastSharedMethods
{
    public void GetSyncValue(int value)
    {
    }

    public void GetSyncedTime(double time)
    {
    }

    public void GetTimeSinceStart(float time)
    {
    }

    public void GetTimeRemaining(float time)
    {
    }

    public void IsServer(bool server)
    {
    }

    public void IsClient(bool client, ulong steamId)
    {
    }

    public void OnDamageableObjectDamaged(GameObject damageableObject, int damageableObjectId, int shipId, int oldHp, int newHp)
    {
    }

    public void OnPlayerHurt(int playerId, byte oldHp, byte newHp, EntityHealthChangedReason reason)
    {
    }

    public void OnPlayerKilledPlayer(int killerPlayerId, int victimPlayerId, EntityHealthChangedReason reason, string additionalDetails)
    {
    }

    public void OnPlayerShoot(int playerId, bool dryShot)
    {
    }

    public void OnPlayerSpawned(int playerId, int spawnSectionId, FactionCountry playerFaction, PlayerClass playerClass, int uniformId, GameObject playerObject, ulong steamId, string playerName, string regimentTag, bool isBot)
    {
    }

    public void OnScorableAction(int playerId, byte score, ScorableActionType reason)
    {
    }

    public void OnTextMessage(int playerId, TextChatChannel channel, string text)
    {
    }

    public void OnRoundDetails(int roundId, string serverName, string mapName, FactionCountry attackingFaction, FactionCountry defendingFaction, GameplayMode gameplayMode, GameType gameType)
    {
    }

    public void OnPlayerBlock(int attackingPlayerId, int defendingPlayerId)
    {
    }

    public void OnPlayerMeleeStartSecondaryAttack(int playerId)
    {
    }

    public void OnPlayerWeaponSwitch(int playerId, string weapon)
    {
    }

    public void OnCapturePointCaptured(int capturePoint)
    {
    }

    public void OnCapturePointOwnerChanged(int capturePoint, FactionCountry factionCountry)
    {
    }

    public void OnCapturePointDataUpdated(int capturePoint, int defendingPlayerCount, int attackingPlayerCount)
    {
    }

    public void OnRoundEndFactionWinner(FactionCountry factionCountry, FactionRoundWinnerReason reason)
    {
    }

    public void OnRoundEndPlayerWinner(int playerId)
    {
    }

    public void OnPlayerStartCarry(int playerId, CarryableObjectType carryableObject)
    {
    }

    public void OnPlayerEndCarry(int playerId)
    {
    }

    public void OnPlayerShout(int playerId, CharacterVoicePhrase voicePhrase)
    {
    }

    public void OnInteractableObjectInteraction(int playerId, int interactableObjectId, GameObject interactableObject, InteractionActivationType interactionActivationType, int nextActivationStateTransitionIndex)
    {
    }

    public void PassConfigVariables(string[] value)
    {
    }

    public void OnEmplacementPlaced(int itemId, GameObject objectBuilt, EmplacementType emplacementType)
    {
    }

    public void OnEmplacementConstructed(int itemId)
    {
    }

    public void OnBuffStart(int playerId, BuffType buff)
    {
    }

    public void OnBuffStop(int playerId, BuffType buff)
    {
    }

    public void OnShotInfo(int playerId, int shotCount, Vector3[][] shotsPointsPositions, float[] trajectileDistances, float[] distanceFromFiringPositions, float[] horizontalDeviationAngles, float[] maxHorizontalDeviationAngles, float[] muzzleVelocities, float[] gravities, float[] damageHitBaseDamages, float[] damageRangeUnitValues, float[] damagePostTraitAndBuffValues, float[] totalDamages, Vector3[] hitPositions, Vector3[] hitDirections, int[] hitPlayerIds, int[] hitDamageableObjectIds, int[] hitShipIds, int[] hitVehicleIds)
    {
    }

    public void OnVehicleSpawned(int vehicleId, FactionCountry vehicleFaction, PlayerClass vehicleClass, GameObject vehicleObject, int ownerPlayerId)
    {
    }

    public void OnVehicleHurt(int vehicleId, byte oldHp, byte newHp, EntityHealthChangedReason reason)
    {
    }

    public void OnPlayerKilledVehicle(int killerPlayerId, int victimVehicleId, EntityHealthChangedReason reason, string details)
    {
    }

    public void OnShipSpawned(int shipId, GameObject shipObject, FactionCountry shipfaction, ShipType shipType)
    {
    }

    public void OnShipDamaged(int shipId, int oldHp, int newHp)
    {
    }
}