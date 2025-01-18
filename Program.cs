using System;
using System.Diagnostics;

namespace Extravert
{
  class Program
  {
    static void Main()
    {

      List<Plant> plants = new List<Plant>
{
  new Plant { Species = "Dracaena", LightNeeds = 1, AskingPrice = 15.00M, City = "Chicago", ZIP = 60601, Sold = false, AvailableUntil = new DateTime(2025, 1, 2) },
  new Plant { Species = "Spider Plant", LightNeeds = 2, AskingPrice = 10.00M, City = "Chicago", ZIP = 60601, Sold = false, AvailableUntil = new DateTime(2025, 6, 12) },
  new Plant { Species = "Azalea", LightNeeds = 3, AskingPrice = 20.00M, City = "Mobile", ZIP = 36608, Sold = false },
  new Plant { Species = "Sunflower", LightNeeds = 5, AskingPrice = 25.00M, City = "New York", ZIP = 10001, Sold = true, AvailableUntil = new DateTime(2024, 12, 31) },
  new Plant { Species = "Pothos", LightNeeds = 5, AskingPrice = 8.00M, City = "Nashville", ZIP = 37250, Sold = true, AvailableUntil = new DateTime(2024, 12, 31) },
};

      string? readResult = null;
      string menuSelection = "start";


      Random rnd = new Random();
      int randomInt = rnd.Next(0, plants.Count);

      do
      {
        Console.WriteLine("SELECT AN OPTION:");
        Console.WriteLine(" 1. See all plants");
        Console.WriteLine(" 2. Post a new plant for sale");
        Console.WriteLine(" 3. Buy a plant");
        Console.WriteLine(" 4. Remove a plant listing");
        Console.WriteLine(" 5. See the plant of the day");
        Console.WriteLine(" 6. Search for a Plant by its Light Needs");
        Console.WriteLine(" 7. See plant statistics");
        Console.WriteLine(" 8. Exit");

        readResult = Console.ReadLine();
        if (readResult != null)
        {
          menuSelection = readResult.ToLower();
        }

        if (menuSelection == "1")
        {
          // List all plants for sale
          Console.Clear();
          Console.WriteLine("Option 1 selected!");

          for (int i = 0; i < plants.Count; i++)
          {
            Console.WriteLine(PlantDetails(plants[i]));
          }

          menuSelection = "start";
          continue;
        }

        else if (menuSelection == "2")
        {

          string newSpecies = "";
          int newLightNeeds = 0;
          decimal newAskingPrice = 0;
          string newCity = "";
          int newZIP = 0;
          DateTime newAvailableUntil = new DateTime(2025, 1, 1);

          bool validEntry = false;

          // Post a new plant for sale
          // The new plant should be added to the array of plants
          Console.Clear();
          Console.WriteLine("Option 2 selected!");

          do
          {
            Console.WriteLine("Enter the name (species) of the plant:");
            readResult = Console.ReadLine();
            if (readResult != null)
            {
              newSpecies = readResult;
              validEntry = true;
            }
            else
            {
              Console.WriteLine("Invalid entry. Please try again.");
              continue;
            }
          } while (validEntry == false);

          do
          {
            Console.WriteLine("Enter the light needs of the plant (1-5):");
            readResult = Console.ReadLine();
            if (readResult != null)
            {
              newLightNeeds = Convert.ToInt32(readResult);
              validEntry = true;
            }
            else if (Convert.ToInt32(readResult) < 1 || Convert.ToInt32(readResult) > 5)
            {
              Console.WriteLine("Please enter a valid number between 1 and 5.");
              continue;
            }
            else
            {
              Console.WriteLine("Invalid entry. Please try again.");
              continue;
            }
          } while (validEntry == false);

          do
          {
            Console.WriteLine("Enter the asking price of the plant:");
            readResult = Console.ReadLine();
            if (readResult != null)
            {
              newAskingPrice = Convert.ToDecimal(readResult);
              validEntry = true;
            }
            else
            {
              Console.WriteLine("Invalid entry. Please try again.");
              continue;
            }
          } while (validEntry == false);

          do
          {
            Console.WriteLine("Enter the city where the plant is located:");
            readResult = Console.ReadLine();
            if (readResult != null)
            {
              newCity = readResult;
              validEntry = true;
            }
            else
            {
              Console.WriteLine("Invalid entry. Please try again.");
              continue;
            }
          } while (validEntry == false);

          do
          {
            Console.WriteLine("Enter the ZIP code where the plant is located:");
            readResult = Console.ReadLine();
            if (readResult != null)
            {
              newZIP = Convert.ToInt32(readResult);
              validEntry = true;
            }
            else
            {
              Console.WriteLine("Invalid entry. Please try again.");
              continue;
            }

          } while (validEntry == false);

          try
          {
            do
            {
              Console.WriteLine("Enter the date the plant will be available until (YYYY-MM-DD):");
              readResult = Console.ReadLine();
              if (readResult != null)
              {
                newAvailableUntil = Convert.ToDateTime(readResult);
                validEntry = true;
              }
              else
              {
                Console.WriteLine("Invalid entry. Please try again.");
                continue;
              }

            } while (validEntry == false);

          }
          catch (FormatException)
          {
            Console.WriteLine("Invalid date entered. Please try again.");

            continue;
          }
          // Take the plant information and add it to the plants list.
          plants.Add(new Plant { Species = newSpecies, LightNeeds = newLightNeeds, AskingPrice = newAskingPrice, City = newCity, ZIP = newZIP, Sold = false, AvailableUntil = newAvailableUntil });

          menuSelection = "start";
          continue;
        }


        else if (menuSelection == "3")
        {
          Console.Clear();
          Console.WriteLine("Option 3 selected!");
          int selection;

          for (int i = 0; i < plants.Count; i++)
          {
            if (plants[i].Sold == false && (plants[i].AvailableUntil > DateTime.Now))
            {
              Console.WriteLine($"{i}. {PlantDetails(plants[i])} ");
            }
          }

          readResult = Console.ReadLine();
          selection = Convert.ToInt32(readResult);

          if ((plants[selection].Sold == false) && (plants[selection].AvailableUntil > DateTime.Now))
          {
            plants[selection].Sold = true;
            Console.WriteLine($"You have purchased a {plants[selection].Species} for {plants[selection].AskingPrice}.");
          }

          menuSelection = "start";
        }


        else if (menuSelection == "4")
        {
          Console.Clear();
          Console.WriteLine("Option 4 selected!");
          menuSelection = "start";

          for (int i = 0; i < plants.Count; i++)
          {
            Console.WriteLine($"{i + 1}. {plants[i].Species} in {plants[i].City}");
          }

          readResult = Console.ReadLine();
          int selection = Convert.ToInt32(readResult);
          plants.RemoveAt(selection - 1);

          continue;
        }


        else if (menuSelection == "5")
        {
          Console.Clear();
          Console.WriteLine("Option 5 selected!");
          // Random plant of the day

          bool validResult = false;

          do
          {

            if (plants[randomInt].Sold == false)
            {
              Console.WriteLine($"The plant of the day is a {plants[randomInt].Species} in {plants[randomInt].City} for {plants[randomInt].AskingPrice}.");

              validResult = true;
            }
            else
            {
              randomInt = rnd.Next(0, plants.Count);

            }

          } while (validResult == false);

          continue;
        }


        else if (menuSelection == "6")
        {
          Console.Clear();
          Console.WriteLine("Option 6 selected!");
          // Search for a Plant by its Light Needs

          Console.WriteLine("Enter the light needs of the plant (1-5):");
          readResult = Console.ReadLine();

          List<Plant> validPlants = new List<Plant>
          {

          };

          for (int i = 0; i < plants.Count; i++)
          {
            if (plants[i].LightNeeds == Convert.ToInt32(readResult))
            {
              validPlants.Add(plants[i]);

              Console.WriteLine(PlantDetails(plants[i]));
            }

          }
          if (validPlants.Count == 0)
          {
            Console.WriteLine("No plants with that light need were found.");
          }

          continue;
        }

        else if (menuSelection == "7")
        {
          // Show plant statistics
          Console.Clear();
          Console.WriteLine("Option 7 selected!");


          // Cheapest plant
          decimal lowestPrice = plants.Min(plant => plant.AskingPrice);

          foreach (Plant plant in plants)
          {

            if (plant.AskingPrice <= lowestPrice)
            {
              lowestPrice = Convert.ToInt32(plant.AskingPrice);

              Console.WriteLine($"{plant.Species} is the cheapest available plant at ${plant.AskingPrice}");
            }

          }

          // Number of plants available
          Console.WriteLine($"There are currently {plants.Count} plants available for sale.");

          // Name of plant with highest light needs
          int highestLightNeeds = plants.Max(plant => plant.LightNeeds);

          foreach (Plant plant in plants)
          {
            if (plant.LightNeeds >= highestLightNeeds)
            {
              highestLightNeeds = plant.LightNeeds;

              Console.WriteLine($"{plant.Species} has the highest light needs at {plant.LightNeeds}");
            }
          }

          // Average light needs
          int averageLightNeeds = (int)plants.Average(plant => plant.LightNeeds);

          Console.WriteLine($"The average light needs of all plants is {averageLightNeeds}");

          // Percentage of plants sold
          int plantsSold = plants.Count(plant => plant.Sold == true);

          double percentageSold = plantsSold / (double)plants.Count * 100;

          Console.WriteLine($"{percentageSold}% of plants have been sold.");
        }


        else if (menuSelection == "8")
        {
          Console.WriteLine("Goodbye!");
          break;
        }
        else
        {
          Console.Clear();
          Console.WriteLine("Please enter a valid menu selection.");
          menuSelection = "start";
        }

      } while (menuSelection != "exit");
    }

   static string PlantDetails(Plant plant)
    {
      string plantString = plant.Species;
      string lightString = plant.LightNeeds.ToString();
      string priceString = plant.AskingPrice.ToString();
      string cityString = plant.City;
      string zipsString = plant.ZIP.ToString();
      bool justSold = plant.Sold;
      string availableUntilString = plant.AvailableUntil.ToString();


      return $"A {plantString} with a Light Need of {lightString} is available in {cityString} {zipsString} for ${priceString}. It {(justSold ? " has been sold." : $"is available until {availableUntilString} ")}";
    }
  }
}
