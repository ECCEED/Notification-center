<template>
  <div>
    <nav class="navbar">
      <div class="navbar-content">
        <router-link to="/">Home</router-link>
        <router-link to="/show-templates">Show Templates</router-link>
      </div>
    </nav>
    <div class="template-form-container">
      <h1 class="title">Add Template</h1>
      <div class="template-form">
        <img
          src="https://i.imgur.com/xQImuuX.png"
          alt="NeoLedge Logo"
          class="logo"
        />
        <div class="form-group">
          <label for="template-name">Template Name</label>
          <input type="text" id="template-name" v-model="templateName" />
        </div>
        <div class="form-group">
          <label for="subject">Subject</label>
          <input type="text" id="subject" v-model="subject" />
        </div>
        <div class="form-group">
          <label for="description">Description</label>
          <textarea id="description" v-model="description"></textarea>
        </div>
        <div class="form-group">
          <label for="logo">Logo</label>
          <input type="file" id="logo" @change="onFileChange" />
        </div>
        <button @click="save">Save</button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      templateName: "",
      subject: "",
      description: "",
      logo: null,
    };
  },
  methods: {
    onFileChange(e) {
      const file = e.target.files[0];
      this.logo = file;
    },
    save() {
      console.log("Template saved:", {
        templateName: this.templateName,
        subject: this.subject,
        description: this.description,
        logo: this.logo,
      });
    },
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

.template-form-container {
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

.template-form {
  background-color: #ffffff;
  padding: 40px;
  border-radius: 10px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  width: 800px; /* Augmenter la largeur du formulaire */
  font-family: "Arial", sans-serif;
}

.form-group {
  margin-bottom: 20px;
}

.logo {
  display: block;
  margin: 0 auto 20px;
  width: 120px;
  height: auto;
}

input[type="text"],
textarea {
  width: calc(100% - 20px);
  padding: 10px;
  border: 1px solid #d1d5db;
  border-radius: 8px;
  font-size: 16px;
  margin-top: 8px;
}

textarea {
  height: 150px; /* Augmenter la hauteur du textarea */
}

input[type="file"] {
  width: 100%;
  padding: 10px;
  border: 1px solid #d1d5db;
  border-radius: 8px;
  margin-top: 8px;
}

button {
  display: block;
  width: 100%;
  padding: 15px;
  background-color: #0c6c8c;
  color: white;
  border: none;
  border-radius: 8px;
  cursor: pointer;
  font-size: 16px;
}

button:hover {
  background-color: #0056b3;
}

label {
  font-weight: bold;
  display: block;
  margin-bottom: 5px;
  color: #1f2937;
}
</style>
