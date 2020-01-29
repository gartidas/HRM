namespace WebApi.Entities
{
    public class Evaluation
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public EvaluationWeight Weight { get; set; }
        public EvaluationType Type { get; set; }
        public int GrantedByID { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeID { get; set; }

    }
    public enum EvaluationWeight
    {
        High = 3,
        Medium = 2,
        Low = 1
    }
    public enum EvaluationType
    {
        Positive = 1,
        Negative = 0
    }
}
