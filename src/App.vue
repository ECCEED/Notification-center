<template>
  <div id="app">
    <nav class="navbar"></nav>
    <div class="main-content">
      <router-view />
      <!-- Composant de vue dynamique pour afficher les composants correspondant aux routes -->
    </div>
  </div>
</template>

<script>
import { defineComponent } from "vue"; // Importer defineComponent de vue

export default defineComponent({
  name: "App",
});
</script>

<style>
/* Styles globaux */
body {
  font-family: Arial, sans-serif;
  background-color: #d4e4ec; /* Ajusté pour correspondre à la charte graphique */
  margin: 0;
  padding: 0;
}

#app {
  text-align: center;
}

.navbar {
  position: fixed;
  top: 0;
  width: 100%;
  height: 80px;
  background-color: #0c6c8c;
  border-bottom: 1px solid #e5e7eb;
  padding: 10px 20px;
  display: flex;
  justify-content: flex-end;
  z-index: 1000; /* Pour s'assurer que la barre de navigation reste au-dessus du contenu */
  box-sizing: border-box;
}

.navbar-list {
  list-style-type: none;
  margin: 0;
  padding: 0;
  display: flex;
  align-items: center;
}

.navbar-item {
  margin-left: 20px;
}

.navbar-item a {
  text-decoration: none;
  color: #007bff; /* Couleur du lien */
  font-weight: bold;
  font-size: 18px; /* Taille de police plus grande pour s'assurer que le texte est bien visible */
}

.navbar-item a:hover {
  color: #0056b3; /* Couleur du lien au survol */
}

.main-content {
  padding-top: 60px; /* Ajuster pour donner de l'espace pour la barre de navigation */
}

/* Optionnel: Ajoutez des styles supplémentaires pour correspondre à la charte graphique */
h1,
h2,
h3,
h4,
h5,
h6 {
  color: #1f2937; /* Couleur des titres */
  font-weight: normal;
}

p {
  color: #4b5563; /* Couleur des paragraphes */
}

a {
  color: #3b82f6; /* Couleur des liens */
  text-decoration: none;
}

a:hover {
  text-decoration: underline;
}
</style>
