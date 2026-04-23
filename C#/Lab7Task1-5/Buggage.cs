/*namespace nickEnv
{
    [Serializable]
    public struct Buggage
    {
        public string name;
        public double weight;

        public Buggage(string name, double weight)
        {
            this.Weight = weight;
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (value > 0)
                {
                    weight = value;
                }
            }
        }
    }
}*/