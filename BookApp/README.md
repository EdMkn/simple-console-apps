# 📚 Book Manager — ASP.NET Core MVC + API REST

Une application web de gestion de livres qui combine :

- ✅ Un frontend MVC avec Razor Views
- ✅ Une API RESTful pour interagir avec les données
- ✅ Swagger pour tester les endpoints
- ✅ Stockage en mémoire (pour l’instant)

---

## 🚀 Démarrage rapide

### 1. Cloner le projet

```bash
git clone https://github.com/votre-utilisateur/book-manager.git
cd book-manager
```

### 2. Restaurer les packages

```bash
dotnet restore
```

### 3. Lancer l'application

```bash
dotnet run
```

Accéder à l'interface :

🌐 Interface web (MVC) : http://localhost:5237/Books

🧪 Swagger UI : http://localhost:5237/swagger

## 🧱 Structure du projet

```bash
BookApp/
├── Controllers/
│   ├── BooksController.cs         # Contrôleur MVC
│   └── BooksApiController.cs      # Contrôleur API REST
├── Models/
│   └── Book.cs                    # Modèle Book
├── Views/Books/                   # Vues Razor (Index, Create, Edit, etc.)
├── Program.cs                     # Configuration de l'application
└── README.md
```

## 🛠️ Technologies utilisées

- .NET 8

- ASP.NET Core MVC

- API REST avec [ApiController]

- Razor Pages

- Swagger (Swashbuckle)

- Bootstrap (via CDN)

## ✅ Fonctionnalités actuelles

- Affichage de la liste des livres (MVC)

- Ajout, modification, suppression via l’interface web

- Endpoints REST : GET, POST, PUT, DELETE

- Interface Swagger pour tester l’API

- Stockage en mémoire (liste statique)

