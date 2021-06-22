<template>
  <div id="app">
    <Navbar />
    <Header />
    <Content />
  </div>
</template>

<script>
import Navbar from './components/layouts/TheNavbar.vue';
import Header from './components/layouts/TheHeader.vue';
import Content from './components/layouts/TheContent.vue';

export default ({
    name: "App",
    components: {
    Navbar,
    Header,
    Content
  },
})
</script>
<style>
@import "./styles/index.css";
</style>
