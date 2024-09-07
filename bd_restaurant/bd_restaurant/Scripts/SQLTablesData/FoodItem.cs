namespace bd_restaurant.Scripts.SQLTablesData
{
    public class FoodItem
    {
        public static readonly string SQL_FoodItemID = "FoodID";
        public static readonly string SQL_Name = "Name";
        public static readonly string SQL_CountValue = "CountValue";
        public static readonly string SQL_Measure = "Measure";
        public static readonly string SQL_Price = "Price";
        public static readonly string SQL_ImageName = "ImageName";


        private int foodItemId;
        private string name;
        private int countValue;
        private string measure;
        private float price;
        private string imageName;


        public string ImagePath => $"E:\\Fork\\bd_restaurant\\bd_restaurant\\bd_restaurant\\Images\\{imageName}.png";

        public int FoodItemId => foodItemId;
        public string Name => name;

        public int CountValue => countValue;
        public string Measure => measure;
        public float Price => price;
        public string ImageName => imageName;


        public FoodItem(int foodItemId, string name, int countValue, string measure, float price, string imageName)
        {
            this.foodItemId = foodItemId;
            this.name = name;
            this.countValue = countValue;
            this.measure = measure;
            this.price = price;
            this.imageName = imageName;
        }

        public override string ToString()
        {
            return $"ID: {foodItemId}\nName: {name}\nCount: {countValue} {measure}\nPrice: {price}\nImageName: {imageName}\n";
        }

    }
}
