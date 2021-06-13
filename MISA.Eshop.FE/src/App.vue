<template>
  <div id="app">
    <Navbar />
    <Header />
    <Content />
  </div>
</template>

<script>
import Navbar from './components/layouts/Navbar.vue';
import Header from './components/layouts/Header.vue';
import Content from './components/layouts/Content.vue';

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
