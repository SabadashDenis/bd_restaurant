namespace bd_restaurant.Scripts.SQLTablesData
{
    public class FoodItem
    {
        public static readonly string SQL_FoodItemID = "FoodID";
        public static readonly string SQL_Name = "Name";
        public static readonly string SQL_CountValue = "CountValue";
        public static readonly string SQL_Measure = "Measure";
        public static readonly string SQL_Price = "Price";


        private int foodItemId;
        private string name;
        private int countValue;
        private string measure;
        private float price;


        public string ImagePath => "E:\\Fork\\bd_restaurant\\bd_restaurant\\bd_restaurant\\Images\\restaurant-logo.png";

        public int FoodItemId => foodItemId;
        public string Name => name;

        public int CountValue => countValue;
        public string Measure => measure;
        public float Price => price;


        public FoodItem(int foodItemId, string name, int countValue, string measure, float price)
        {
            this.foodItemId = foodItemId;
            this.name = name;
            this.countValue = countValue;
            this.measure = measure;
            this.price = price;
        }

        public override string ToString()
        {
            return $"ID: {foodItemId}\nName: {name}\nCount: {countValue} {measure}\nPrice: {price}";
        }

    }
}
