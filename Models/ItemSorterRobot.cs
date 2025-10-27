namespace Afl6.Models
{
    public class ItemSorterRobot : Robot
    {
       
        public const string UrscriptTemplate = @"
def move_item_to_shipment_box():
  BOX_X = 0.40     # placering af 'skibskasse'
  BOX_Y = -0.20
  ITEM_X = {0}     # hvert item får sin egen X-position
  ITEM_Y = -0.40
  Z_UP = 0.20
  Z_DOWN = 0.05

  movel(p[ITEM_X, ITEM_Y, Z_UP, 0, 3.14, 0], a=1.0, v=0.25)
  movel(p[ITEM_X, ITEM_Y, Z_DOWN, 0, 3.14, 0], a=1.0, v=0.25)
  movel(p[ITEM_X, ITEM_Y, Z_UP, 0, 3.14, 0], a=1.0, v=0.25)

  movel(p[BOX_X, BOX_Y, Z_UP, 0, 3.14, 0], a=1.0, v=0.25)
  movel(p[BOX_X, BOX_Y, Z_DOWN, 0, 3.14, 0], a=1.0, v=0.25)
  movel(p[BOX_X, BOX_Y, Z_UP, 0, 3.14, 0], a=1.0, v=0.25)

  textmsg(""Item moved!"")
end
";

        public void PickUp(uint itemId)
        {
           
            double xPos = 0.20 + (itemId * 0.05);
            var script = string.Format(UrscriptTemplate, xPos.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture));
            SendUrsript(script);
        }
    }
}