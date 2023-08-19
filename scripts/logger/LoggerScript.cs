// LoggerScript.cs
// A simple script to log out some details of the round. Most technical details are ommitted from this script.

using HoldfastSharedMethods;
using UnityEngine;

public class LoggerScript : IHoldfastSharedMethods
{
    float timeRemaining = 0f;

    public void OnSyncValueState(int value) {
    }

    public void OnUpdateSyncedTime(double time) {
    }

    public void OnUpdateElapsedTime(float time) {
    }

    public void OnUpdateTimeRemaining(float time) {
        timeRemaining = time;
    }

    public void OnIsServer(bool server) {
    }

    public void OnIsClient(bool client, ulong steamId) {
    }

    public void OnDamageableObjectDamaged(GameObject damageableObject, int damageableObjectId, int shipId, int oldHp, int newHp) {
        Debug.Log(string.Format("[{0}] - Damageable Object {1}/{2} (shipId {3}) HP changed (old={4}, new={5})", timeRemaining, damageableObject, damageableObjectId, shipId, oldHp, newHp));
    }

    public void OnPlayerHurt(int playerId, byte oldHp, byte newHp, EntityHealthChangedReason reason) {
        Debug.Log(string.Format("[{0}] - Player ID={1} HP changed ({2} -> {3}) with reason {4}", timeRemaining, playerId, oldHp, newHp, reason));
    }

    public void OnPlayerKilledPlayer(int killerPlayerId, int victimPlayerId, EntityHealthChangedReason reason, string additionalDetails) {
        Debug.Log(string.Format("[{0}] - Player {1} killed by player {2}, reason -> {3}, additional details -> {4}", timeRemaining, killerPlayerId, victimPlayerId, reason, additionalDetails));
    }

    public void OnPlayerShoot(int playerId, bool dryShot) {
    }

    public void OnPlayerJoined(int playerId, ulong steamId, string playerName, string regimentTag, bool isBot) {
        Debug.Log(string.Format("[{0}] - Player {1} (steam={2}, name={3}, regiment={4}, isBot={5}) joined the server", timeRemaining, playerId, steamId, playerName, regimentTag, isBot));
    }

    public void OnPlayerLeft(int playerId) {
        Debug.Log(string.Format("[{0}] - Player {1} left the server", timeRemaining, playerId));
    }

    public void OnPlayerSpawned(int playerId, int spawnSectionId, FactionCountry playerFaction, PlayerClass playerClass, int uniformId, GameObject playerObject) {
        Debug.Log(string.Format("[{0}] - Player {1} spawned (spawn={2}, faction={3}, class={4}, uniformId={5})", timeRemaining, playerId, spawnSectionId, playerFaction, playerClass, uniformId));
    }

    public void OnScorableAction(int playerId, int score, ScorableActionType reason) {
    }

    public void OnTextMessage(int playerId, TextChatChannel channel, string text) {
        Debug.Log(string.Format("[{0}] - Player {1} sent a message in channel {2}: {3}", timeRemaining, playerId, channel, text));
    }

    public void OnRoundDetails(int roundId, string serverName, string mapName, FactionCountry attackingFaction, FactionCountry defendingFaction, GameplayMode gameplayMode, GameType gameType) {
        Debug.Log(string.Format("[{0}] - Round details: Id={1}, serverName={2}, mapName={3}, attacking={4}, defending={5}, gameMode={6}, gameType={7}", timeRemaining, roundId, serverName, mapName, attackingFaction, defendingFaction, gameplayMode, gameType));
    }

    public void OnPlayerBlock(int attackingPlayerId, int defendingPlayerId) {
    }

    public void OnPlayerMeleeStartSecondaryAttack(int playerId) {
    }

    public void OnPlayerWeaponSwitch(int playerId, string weapon) {
    }

    public void OnCapturePointCaptured(int capturePoint) {
    }

    public void OnCapturePointOwnerChanged(int capturePoint, FactionCountry factionCountry) {
        Debug.Log(string.Format("[{0}] - Capture point {1} captured by {2}", timeRemaining, capturePoint, factionCountry));
    }

    public void OnCapturePointDataUpdated(int capturePoint, int defendingPlayerCount, int attackingPlayerCount) {
    }

    public void OnRoundEndFactionWinner(FactionCountry factionCountry, FactionRoundWinnerReason reason) {
        Debug.Log(string.Format("[{0}] - {1} won the round with reason: {2}", timeRemaining, factionCountry, reason));
    }

    public void OnRoundEndPlayerWinner(int playerId) {
        Debug.Log(string.Format("[{0}] - Player {1} won the round", timeRemaining, playerId));
    }

    public void OnPlayerStartCarry(int playerId, CarryableObjectType carryableObject) {
        Debug.Log(string.Format("[{0}] - Player {1} started carrying a {2}", timeRemaining, playerId, carryableObject));
    }

    public void OnPlayerEndCarry(int playerId) {
        Debug.Log(string.Format("[{0}] - Player {1} ended carry", timeRemaining, playerId));
    }

    public void OnPlayerShout(int playerId, CharacterVoicePhrase voicePhrase) {
    }

    public void OnInteractableObjectInteraction(int playerId, int interactableObjectId, GameObject interactableObject, InteractionActivationType interactionActivationType, int nextActivationStateTransitionIndex) {
    }

    public void PassConfigVariables(string[] value) {
    }

    public void OnEmplacementPlaced(int itemId, GameObject objectBuilt, EmplacementType emplacementType) {
    }

    public void OnEmplacementConstructed(int itemId) {
    }

    public void OnBuffStart(int playerId, BuffType buff) {
    }

    public void OnBuffStop(int playerId, BuffType buff) {
    }

    public void OnShotInfo(int playerId, int shotCount, Vector3[][] shotsPointsPositions, float[] trajectileDistances, float[] distanceFromFiringPositions, float[] horizontalDeviationAngles, float[] maxHorizontalDeviationAngles, float[] muzzleVelocities, float[] gravities, float[] damageHitBaseDamages, float[] damageRangeUnitValues, float[] damagePostTraitAndBuffValues, float[] totalDamages, Vector3[] hitPositions, Vector3[] hitDirections, int[] hitPlayerIds, int[] hitDamageableObjectIds, int[] hitShipIds, int[] hitVehicleIds) {
    }

    public void OnVehicleSpawned(int vehicleId, FactionCountry vehicleFaction, PlayerClass vehicleClass, GameObject vehicleObject, int ownerPlayerId) {
    }

    public void OnVehicleHurt(int vehicleId, byte oldHp, byte newHp, EntityHealthChangedReason reason) {
    }

    public void OnPlayerKilledVehicle(int killerPlayerId, int victimVehicleId, EntityHealthChangedReason reason, string details) {
        Debug.Log(string.Format("[{0}] - Player {1} killed vehicle {2}", timeRemaining, killerPlayerId, victimVehicleId));
    }

    public void OnShipSpawned(int shipId, GameObject shipObject, FactionCountry shipfaction, ShipType shipType, int shipNameId) {
    }

    public void OnShipDamaged(int shipId, int oldHp, int newHp) {
    }

    public void OnAdminPlayerAction(int playerId, int adminId, ServerAdminAction action, string reason) {
    }

    public void OnConsoleCommand(string input, string output, bool success) {
    }

    public void OnRCLogin(int playerId, string inputPassword, bool isLoggedIn) {
    }

    public void OnRCCommand(int playerId, string input, string output, bool success) {
    }

    public void OnPlayerPacket(int playerId, byte? instance, Vector3? ownerPosition, double? packetTimestamp, Vector2? ownerInputAxis, float? ownerRotationY, float? ownerPitch, float? ownerYaw, PlayerActions[] actionCollection, Vector3? cameraPosition, Vector3? cameraForward, ushort? shipID, bool swimming) {
    }

    public void OnVehiclePacket(int vehicleId, Vector2 inputAxis, bool shift, bool strafe, PlayerVehicleActions[] actionCollection) {
    }

    public void OnOfficerOrderStart(int officerPlayerId, HighCommandOrderType highCommandOrderType, Vector3 orderPosition, float orderRotationY, int voicePhraseRandomIndex) {
    }

    public void OnOfficerOrderStop(int officerPlayerId, HighCommandOrderType highCommandOrderType) {
    }
}