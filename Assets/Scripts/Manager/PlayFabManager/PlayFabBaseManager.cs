using Cysharp.Threading.Tasks;
using PlayFab;
using UnityEngine;

namespace Manager.PlayFabManager
{
    public class PlayFabBaseManager
    {
        public static async UniTask<object> AzureFunctionAsync(string functionName)
        {
            var request = new PlayFab.CloudScriptModels.ExecuteFunctionRequest
            {
                Entity = new PlayFab.CloudScriptModels.EntityKey
                {
                    Id = PlayFabSettings.staticPlayer.EntityId,
                    Type = PlayFabSettings.staticPlayer.EntityType
                },
                FunctionName = functionName,
                FunctionParameter = null,
                GeneratePlayStreamEvent = true
            };

            var result = await PlayFabCloudScriptAPI.ExecuteFunctionAsync(request);
            if (result.Error != null)
            {
                Debug.LogError(result.Error.GenerateErrorReport());
                return null;
            }

            if (result.Result.FunctionResultTooLarge != null && (bool)result.Result.FunctionResultTooLarge)
            {
                Debug.LogError("Function result too large");
                return null;
            }

            return result.Result.FunctionResult;
        }
    }
}