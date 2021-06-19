<template>
  <div class="navbar">
    <div class="logo-site">
      <div class="logo-box">
        <div class="logo-icon"></div>
      </div>
    </div>
    <div class="menu">
      <router-link
        active-class="active"
        class="none-decoation nav-item"
        v-for="(item, index) in menuItem"
        :key="index"
        :to="item.path"
      >
        <div :class="item.class"></div>
        <div class="item-name">{{ item.name }}</div>
      </router-link>
    </div>
    <div class="menu-last">
      <router-link
        active-class="active"
        class="none-decoation nav-item"
        to="/products"
      >
        <div class="icon-product icon"></div>
        <div class="item-name">hàng hóa</div>
      </router-link>
    </div>
  </div>
</template>
<script>
export default {
  name: "Navbar",
  data() {
    return {
      menuItem: [
        {
          path: "/home",
          class: "icon-speed icon",
          name: "Tổng quan",
        },
        {
          path: "/about",
          class: "icon-report icon",
          name: "Báo cáo",
        },
        {
          path: "/cart",
          class: "icon-deliveryledger icon",
          name: "Đơn hàng",
        },
        {
          path: "/byproducts",
          class: "icon-purchares icon",
          name: "Mua hàng",
        },
        {
          path: "/promotion",
          class: "icon-promotion icon",
          name: "Khuyến mại",
        },
        {
          path: "/dictionary/StoreManager",
          class: "icon-managerment icon",
          name: "Quản lý cửa hàng",
        },
      ],
    };
  },
};
</script>
<style scoped>
.active {
  background-color: #1e235a;
}
</style>