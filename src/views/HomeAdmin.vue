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
  margin-top: 20px;
}

.admin-button {
  padding: 10px 20px;
  font-size: 16px;
  color: white;
  background-color: #0c6c8c;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  width: 200px;
}

.admin-button:hover {
  background-color: #0056b3;
}
</style>
