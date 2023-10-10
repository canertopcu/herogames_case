[System.Serializable]
public class Upgrade
{
    public string TargetMachineName;
    public AffectType AffectType;
    public float Power;

    public Upgrade(float power, AffectType affectType, string targetMachine)
    {
        AffectType = affectType;
        TargetMachineName = targetMachine;
        Power = power;
    }
}