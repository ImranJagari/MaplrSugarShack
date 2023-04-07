# Maplr Sugar Shack

Ce projet a été fait à partir des consignes dans le repo https://github.com/Maplr-Community/Sugar-Shack-test-maplr basé sur un template gratuit "Belle multipurpose"

## Pré-requis

- Dotnet 7
- Visual studio 2022
- Blazor Webassembly
- Docker Desktop

## Installation

Lancer le script
```
install.ps1
```

puis executer le projet MaplrSugarShack.Server.

# Technologies utilisées

Pour le front-end, la technologie Blazor Webassembly a été utilisé plus par facilitée, étant un développeur backend, je me suis dirigé vers le la technologie qui me correspondait le mieux.

Pour le back-end, j'ai utilisé de l'ASP.NET Core (sous .NET 7)

et enfin pour le stockage de données, je suis parti, sur MongoDB, pourquoi ce moteur de stockage de données, tout simplement pour 2 raisons :
- la première est, la facilité de stokage des données, Tout est stocké en json, cela rends la manipulation plus facile.
- la deuxième est, en ce qui concerne les performances, j'aurai pu partir sur du SQL et ajouter des index, mais MongoDB n'a pas besoin d'autant de configuration, c'est du prêt à utilisé, sans configuration, la complexité ne survient que si les données commencent à gonfler énormément

## Problématique restantes

- Problème au niveau du filter en JS sur la liste des produits, il faut cliquer sur l'un des types pour que les produits apparaissent.
- Problème de coordination entre le JS du template utilisé et Blazor, étant donné que Blazor ne fait aucun reload de page, il arrive que parfois les JS soient perdus lors de l'application des évenements.

## Piste d'améliorations

- Suite à la sortie de .NET 7, il faudrait migrer sur le déploiement sur container de l'application. (cf https://lippertmarkus.com/2022/12/09/dotnet-7-container-support/)
- Ajouter une fonctionnalité de recherche via SOLR (our elasticsearch) pour la recherche via des types ou par nom.
- Améliorer le design (Malheureusement, n'ayant aucun talent en design, ça a donné ça ! :( )
