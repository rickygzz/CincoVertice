namespace CincoVertice.Food.Units
{
    public class KitchenUnits
    {
        public static string ToString(double teaSpoons)
        {
            double convertedQuantity;
            string convertedUnit;

            if (teaSpoons >= 48)
            {
                // 48 ts = 16 Tsp = 1 Cup
                convertedQuantity = teaSpoons / 48.0;
                convertedUnit = "Tza";
            }
            else if (teaSpoons >= 3)
            {
                convertedQuantity = teaSpoons / 3.0;
                convertedUnit = "Tsp";
            }
            else
            {
                convertedQuantity = teaSpoons;
                convertedUnit = "ts";
            }

            return convertedUnit;
        }
    }
}
