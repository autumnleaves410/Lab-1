namespace Lab_1;

class Program
{
    static void Main(string[] args)
    {
        List<VideoGame> listofGames = new List<VideoGame>(); //makes a new list for video games...referencing the video game class. 


        string rootFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString(); //makes a new directory so that it can find the csv file easier?
        string filePath = $"{rootFolder}{Path.DirectorySeparatorChar}videogames.csv";  //establishes a file path to videogames.csv

        using (var sr = new StreamReader(filePath))
        {
            string[] fileReader = File.ReadAllLines(filePath);

            //Display the contents of each line from file

            for (int i = 1; i < fileReader.Length; i++)
            {
                string line = fileReader[i];

                string? lineTwo = sr.ReadLine();

                string[] lineElements = line.Split(',');


                VideoGame Games = new VideoGame
                {
                    Name = lineElements[0],
                    Platform = lineElements[1],
                    Year = double.Parse(lineElements[2]),
                    Genre = lineElements[3],
                    Publisher = lineElements[4],
                    NA_Sales = decimal.Parse(lineElements[5]),
                    EU_Sales = decimal.Parse(lineElements[6]),
                    JP_Sales = decimal.Parse(lineElements[7]),
                    Other_Sales = decimal.Parse(lineElements[8]),
                    Global_Sales = decimal.Parse(lineElements[9])
                };

                listofGames.Add(Games);
            }

            listofGames = listofGames.OrderBy(record => record.Name).ToList();          ///// ALPHABATIZE SECTION!!!////

            Console.WriteLine("File Contents:");
            foreach (var gameItem in listofGames)
            {
                Console.WriteLine(gameItem);
            }

            Console.WriteLine("Press Enter to Clear");
            Console.Read();
            Console.Clear();



        }


        using (var sr = new StreamReader(filePath))                 ///// PUBLISHER SECTION//////
        {
            try
            {
                var capComGames = listofGames.Where(game => game.Publisher.Equals("Capcom", StringComparison.OrdinalIgnoreCase));
                foreach (var game in capComGames)
                {
                    Console.WriteLine($"Title: {game.Name}, Publisher:  {game.Publisher}");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }


        using (var sr = new StreamReader(filePath))
        {
            try    //Capcom percentage of games
            {

                string publisherChoice = "Capcom";

                var publisherGame = listofGames.Where(game => game.Publisher.Equals(publisherChoice, StringComparison.OrdinalIgnoreCase)).ToList();

                int allGames = listofGames.Count;
                int capComGameCount = publisherGame.Count;

                double percentage = ((double)capComGameCount / allGames) * 100;
                percentage = Math.Round(percentage, 2);


                Console.WriteLine($"Out of {allGames} games, {capComGameCount} are developed by {publisherChoice}, which is {percentage}%");

            }

            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.WriteLine("Press Enter to Clear");
            Console.Read();
            Console.Clear();

        }

        using (var sr = new StreamReader(filePath))
        {
            try   //percentage of shooter games 
            {
                string gameGenre = "Shooter";

                var shooterGame = listofGames.Where(game => game.Genre.Equals(gameGenre, StringComparison.OrdinalIgnoreCase)).ToList();

                int allofGames = listofGames.Count;
                int shooterCount = shooterGame.Count;

                double percentage = ((double)shooterCount / allofGames) * 100;
                percentage = Math.Round(percentage, 2);


                foreach (var gameItem in shooterGame)
                {
                    Console.WriteLine($"Title: {gameItem.Name}, Genre:  {gameItem.Genre}");
                }

                Console.WriteLine($"Out of {allofGames} games, {shooterCount} are shooter games, which is {percentage}%");


            }

            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.WriteLine("Press Enter to Clear");
            Console.Read();
            Console.Clear();

        }

        try
        {

            // Prompt the user for the publisher
            Console.Write("Enter the publisher: ");
            string publisher = Console.ReadLine();

            // Call the PublisherData method to calculate and display data
            PublisherData(listofGames, publisher);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        static void PublisherData(List<VideoGame> listofGames, string publisher)
        {

            var publisherGames = listofGames.Where(games => games.Publisher.Equals(publisher, StringComparison.OrdinalIgnoreCase)).ToList();


            var allGames = listofGames;


            int totalGames = allGames.Count;
            int publisherGamesCount = publisherGames.Count;


            double percentage = ((double)publisherGamesCount / totalGames) * 100;
            percentage = Math.Round(percentage, 2);

            foreach (var gameItem in publisherGames)
            {
                Console.WriteLine($"Title: {gameItem.Name}, Genre: {gameItem.Publisher}");
            }


            Console.WriteLine($"Out of {totalGames} games, {publisherGamesCount} are developed by {publisher}, which is {percentage}%.");

        }


        




        Console.WriteLine("Enter to continue");
        Console.Read();
        Console.Clear();

        try
        {

            // Prompt the user for the genre
            Console.Write("Enter the genre: ");
            string gameGenre = Console.ReadLine();

            // Call the GenreData method to calculate and display data
            GenreData(listofGames, gameGenre);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }



        static void GenreData(List<VideoGame> listofGames, string Genre)
        {

            var genreGames = listofGames.Where(game => game.Genre.Equals(Genre, StringComparison.OrdinalIgnoreCase)).ToList();


            var allGames = listofGames;


            int totalGames = allGames.Count;
            int genreGamesCount = genreGames.Count;

            // Calculate the percentage
            double percentage = (double)genreGamesCount / totalGames * 100;
            percentage = Math.Round(percentage, 2);

            // Display the results
            foreach (var gameItem in genreGames)
            {
                Console.WriteLine($"Title: {gameItem.Name}, Genre: {gameItem.Genre}");
            }

            Console.WriteLine($"Out of {totalGames} games, {genreGamesCount} are of the genre {Genre}, which is {percentage}%.");

        }

        Console.WriteLine("Enter to exit");
        Console.Read();
        Console.Clear();



    }
}
