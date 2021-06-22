<template>
  <div class="loading">
    <div class="load-background"></div>
    <div class="x-mask-loading x-mask-msg-inner">
      <div class="load"><div class="icon-loading"></div></div>
    </div>
  </div>
</template>
<script>
export default {
  name: "BaseLoadingForm",
};
</script>
<style scoped>
.loading {
  position: absolute;
  top: 0px;
  left: 0px;
  bottom: 0px;
  right: 0px;
  z-index: 1000;
}
.load-background {
  position: absolute;
  width: 100%;
  height: 100%;
  background-color: black;
  opacity: 0.3;
}
.x-mask-loading {
  margin-top: 240px;
  padding: 0;
  background-color: transparent;
}
.load {
  background: #d0d0d0;
  width: 20px;
  height: 20px;
  margin-left: 296px;
}
</style>
