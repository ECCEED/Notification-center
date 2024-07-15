<template>
  <div>
    <nav class="navbar">
      <div class="navbar-content">
        <router-link to="/">Home</router-link>
        <router-link to="/add-template">Add Template</router-link>
      </div>
    </nav>
    <div class="template-list-container">
      <h1 class="title">Show Templates</h1>
      <!-- Contenu pour afficher les modèles de formulaire -->
      <ul>
        <li v-for="template in templates" :key="template.id">
          <h3>{{ template.name }}</h3>
          <p>{{ template.description }}</p>
          <!-- Autres détails du modèle -->
        </li>
      </ul>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      templates: [
        // Exemple de données de modèles à afficher
        { id: 1, name: "Modèle 1", description: "Description du modèle 1" },
        { id: 2, name: "Modèle 2", description: "Description du modèle 2" },
        { id: 3, name: "Modèle 3", description: "Description du modèle 3" },
      ],
    };
  },
};
</script>

<style scoped>
.navbar {
  background-color: #0c6c8c; /* Couleur de fond de la navbar */
  padding: 20px; /* Ajustez le padding selon vos besoins */
  width: 100%; /* Assurez-vous que la navbar occupe toute la largeur */
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1); /* Optionnel : ajoute une ombre pour un effet de profondeur */
}

.navbar-content {
  display: flex;
  justify-content: flex-end; /* Aligne le contenu à droite */
  align-items: center;
  max-width: 1200px; /* Largeur maximale de la barre de navigation */
  margin: 0 auto; /* Centre la barre de navigation */
}

.navbar-content a {
  color: white; /* Couleur du texte des liens */
  text-decoration: none; /* Enlève la décoration des liens */
  padding: 10px 20px; /* Espace autour des liens */
}

.navbar-content a:hover {
  background-color: #0056b3; /* Couleur de fond au survol */
  border-radius: 4px; /* Coins arrondis au survol */
}

.template-list-container {
  margin-top: 60px; /* Ajoutez cette ligne pour créer un espace en haut */
  display: flex;
  flex-direction: column;
  align-items: center;
}

.title {
  font-size: 32px;
  font-weight: 400; /* Définir le poids de la police à 400 */
  margin-bottom: 20px; /* Ajustez cette valeur selon l'espacement souhaité */
  color: #0c6c8c; /* Couleur du texte */
  font-family: "Trebuchet MS", sans-serif; /* Définir la police à Trebuchet MS */
}
</style>
