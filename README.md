# Pokemon Master API

##### Description
The Pokemon Master API is a web application that provides a set of RESTful APIs for managing Pokémon data. It allows users to perform various operations such as retrieving information about Pokémon, capturing Pokémon, listing captured Pokémon, and more.

##### FeaturesFeatures
Get Pokemon: Retrieve information about Pokémon based on the provided offset and limit. The API returns a paginated list of Pokémon with details like name and URL.

Get Random Pokemons List: Retrieve a list of random Pokémon. This feature connects with an external service to fetch random Pokémon and returns their names and URLs.

Capture Pokemon: Allows users to capture a Pokémon by providing a trainer ID and a Pokémon ID. The captured Pokémon's details are saved to the database.

List Captured Pokemons: Retrieve a list of Pokémon captured by a specific trainer. The API returns a list of Pokémon with their names and other relevant details.

Get Pokemon List: Retrieve a list of Pokémon based on the provided limit. Similar to the "Get Pokemon" feature, this API returns a paginated list of Pokémon.

Save Searched Pokemon: Allows users to save a searched Pokémon by providing a Pokémon DTO. The saved Pokémon's details are stored in the database.

##### Technologies Used
- **C#**: The backend of the application is developed using C#, a powerful and versatile programming language.
- **ASP.NET Core**: The web application framework used to build APIs.
- **Entity Framework Core**: An Object-Relational Mapping (ORM) framework that simplifies data access in the application.
- **SQLite**: The database system used for storing Pokémon and trainer information.
- **xUnit**: The testing framework used for unit testing the application.

## Setup and Usage

**Clone the Repository:** Use the following command to clone the repository:

[git clone ](https://github.com/yourusername/PokemonMasterAPI.git)

**Set up the Database**: Ensure you have SQLite installed. Use Entity Framework Core migrations to create the database:

>dotnet ef migrations add InitialMigration
>
>dotnet ef database update

**Run the Application**: Start the API by running the following command:
>dotnet run
>
Use the API: Access the API at http://localhost:5000 (or http://localhost:5001 for HTTPS). Use API endpoints like /api/pokemon to interact with the application.

**Tests**
Unit tests are included in the **PokemonMasterAPITests** project. You can run the tests using the following command:

>dotnet test

Contributions
Contributions are welcome! If you find a bug or have an enhancement in mind, please open an issue or create a pull request.

License
This project is licensed under the MIT License.

Acknowledgments
Special thanks to the creators of the [PokeAPI](http://https://pokeapi.co/ "PokeAPI") for providing the Pokémon data used in this application.

**Author**
###### **SHAMIM KASIM**
