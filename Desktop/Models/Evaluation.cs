namespace Desktop.Models
{
    class Evaluation
    {
        public string ID { get; set; }
        public string Description { get; set; }
        public EvaluationWeight Weight { get; set; }
        public bool Type { get; set; }
        public HR_Worker HR_Worker { get; set; }
    }

    public enum EvaluationWeight
    {
        High = 3,
        Medium = 2,
        Low = 1
    }
}
