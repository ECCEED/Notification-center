<template>
  <div class="home-admin">
    <h1>Admin Dashboard</h1>
    <div class="button-container">
      <router-link to="/add-template">
        <button class="admin-button">Add Template</button>
      </router-link>
      <router-link to="/show-templates">
        <button class="admin-button">Show Templates</button>
      </router-link>
    </div>
  </div>
</template>

<script>
export default {
  name: "HomeAdmin",
};
</script>

<style scoped>
.home-admin {
  display: flex;
  flex-direction: column;
  align-items: center;
  margin-top: 50px;
}

.button-container {
  display: flex;
  flex-direction: column;
  gap: 20px;
  margin-top: 80px;
}

.admin-button {
  padding: 20px 40px; /* Augmenter la taille du padding */
  font-size: 20px; /* Augmenter la taille de la police */
  color: white;
  background-color: #0c6c8c;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  width: 300px; /* Augmenter la largeur du bouton */
}

.admin-button:hover {
  background-color: #0056b3;
}

h1 {
  font-size: 32px;
  font-weight: 400; /* Définir le poids de la police à 400 */
  margin-bottom: 20px; /* Ajustez cette valeur selon l'espacement souhaité */
  color: #0c6c8c; /* Couleur du texte */
  font-family: "Trebuchet MS", sans-serif; /* Définir la police à Trebuchet MS */
  margin-top: 60px;
}
</style>
