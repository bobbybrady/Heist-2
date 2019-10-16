namespace heist2
{
    public interface IRobber
    {
        string name {get;set;}
        int SkillLevel{get;set;}
        string specialty { get; }
        int PercentageCut {get;set;}
        void PerformSkill(Bank bank);
    }
}