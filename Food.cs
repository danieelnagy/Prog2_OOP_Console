namespace JopeFinal
{
    class Food
    {
        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public Food(string _type) //ctor för kunna skapa en lista
        {
            type = _type;
        }

        public override string ToString()
        {
            return string.Format("{0}", type);
        }
    }
}
