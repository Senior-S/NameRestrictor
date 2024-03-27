using Rocket.API.Collections;
using Rocket.Core.Plugins;
using SDG.Unturned;
using Steamworks;
using System.Linq;
using Logger = Rocket.Core.Logging.Logger;

namespace SeniorS.NameRestrictor;
public class NameRestrictor : RocketPlugin<Configuration>
{
    public static NameRestrictor Instance;

    protected override void Load()
    {
        Instance = this;

        Provider.onCheckValidWithExplanation += OnCheckValid;

        Logger.Log($"NameRestrictor v{this.Assembly.GetName().Version}");
        Logger.Log("<<SSPlugins>>");
    }

    private void OnCheckValid(ValidateAuthTicketResponse_t callback, ref bool isValid, ref string explanation)
    {
        SteamPending steamPending = Provider.pending.FirstOrDefault(c => c.playerID.steamID == callback.m_OwnerSteamID);
        if (steamPending == null)
        {
            return;
        }

        string restrictedString = Configuration.Instance.restrictedStrings.FirstOrDefault(steamPending.playerID.characterName.Contains);

        if (restrictedString != default(string))
        {
            explanation = Configuration.Instance.shouldNotifyInvalidString ? Translate("rejection_notify_message", restrictedString) : Translate("rejection_message");
            isValid = false;
        }
    }

    public override TranslationList DefaultTranslations => new() 
    {
        { "rejection_message", "Sorry you have invalid strings on your name!" },
        { "rejection_notify_message", "Sorry, you can't have {0} on your name!" }
    };

    protected override void Unload()
    {
        Instance = null;

        Provider.onCheckValidWithExplanation -= OnCheckValid;

        Logger.Log("<<SSPlugins>>");
    }
}