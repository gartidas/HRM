namespace WebApi.Entities.Joins
{
    public class WorkPlaceLeaderCorporateEvent
    {
        public string WorkPlaceLeaderID { get; set; }
        public string CorporateEventID { get; set; }
        public WorkPlaceLeader WorkPlaceLeader { get; set; }
        public CorporateEvent CorporateEvent { get; set; }
    }
}
