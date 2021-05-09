This repository is created for reproducing the issue I ran into during experimenting with GraphQL schemas stitching. 
The essential idea is the following: one entity contains references to the other one. The entities are stored in the different services. GraphQL Gateway is supposed to resolve these references. 

For example: AuthorsService provides the list of authors. Every author may have a set of books. The list of books is stored in the other repository. Author knows Ids of its books. GraphQL Gateway exchanges these IDs for books coming from BooksService. 

It turns out that there are some deserialization issues during loading referenced entities from the other schema by a set of Ids. The type doesn't matter, it may be GUID, int, string.


Do the following steps to reproduce the issue:
1. Open the solution in Visual Studio, configure multiple projects running (select all projects), click "Start"
2. Run the following GraphQL query:
```graphql
{
  authors {
    id
    name
    books {
      id
      title
    }
  }
}
```
3. You'll get the following response:
```json
{
  "errors": [
    {
      "message": "Uuid cannot parse the given value of type `HotChocolate.Language.StringValueNode`."
    }
  ],
  "data": {
    "authors": [
      {
        "id": "1131d4221ca744efba49f198a53084ee",
        "name": "Author 1",
        "books": null
      },
      {
        "id": "838a2bd50ea1491186174ebf79a3063a",
        "name": "Author 2",
        "books": []
      }
    ]
  }
}
```
