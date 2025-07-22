# Visionneuse d’images GTK# (MVC)

Une petite application de bureau écrite en C# avec GTK# pour Linux, organisée selon le modèle MVC.  
Elle permet de parcourir les images d’un dossier local (formats pris en charge : `.jpg`, `.png`, `.bmp`).

---

## ✨ Fonctionnalités

- Ouvre un dossier contenant des images
- Affiche les images une par une
- Boutons "Précédent" et "Suivant"
- Interface graphique native GTK3
- Architecture propre : MVC (Model, View, Controller)

## 🛠️ Dépendances

Assurez-vous d’avoir installé :

- Mono
- GTK# 3

### Installation sous Debian/Ubuntu

```bash
sudo apt update
sudo apt install mono-complete gtk-sharp3
```

## Compilation

À la racine du dossier :

```bash
mcs -debug -pkg:gtk-sharp-3.0 Models/*.cs Views/*.cs Controllers/*.cs Program.cs -out:ImageViewerMVC.exe

```
