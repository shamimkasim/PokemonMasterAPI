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
