<template>
  <div class="dialog-waning">
    <div class="background-dialog-waning"></div>
    <div class="confirm-dialog">
      <div class="confirm-dialog-name">
        <span>Dữ liệu chưa được lưu</span>
        <div class="close-form" @click="close"></div>
      </div>
      <div class="confirm-dialog-content">
        <div class="icon-dialog"></div>
        <div class="text">Dữ liệu đã thay đổi, bạn muốn lưu không?</div>
      </div>
      <div class="confirm-dialog-button">
        <button class="btn-footer-save mgr-8 hover-pointer hover-none" @click="save">
          <div class="icon-footer-save"></div>
          <div class="item-footer-save">Lưu</div>
        </button>
        <button class="btn-footer-add-save mgr-8 hover-pointer hover-none" @click="notSave">
          <div class="item-footer-noSave"></div>
          <div class="item-footer-name-add">Không lưu</div>
        </button>
        <button class="btn-footer-cancel hover-pointer hover-none" @click="close">
          <div class="icon-footer-cancel"></div>
          <div class="item-footer-name-cancel">Hủy bỏ</div>
        </button>
      </div>
    </div>
  </div>
</template>

<script>
export default ({
    name: 'DialogSaveData',
    methods: {
        close(){
            this.$emit("closeTabSaveData");
        },
        notSave(){
            this.$emit("closeTabNoSave");
        },
        save(){
            this.$emit("closeTabSave");
        },
    },
})
</script>

<style>
@import "../../styles/dialog/dialogSaveData.css";
</style>