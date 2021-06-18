<template>
    <div class="dialog-waning">
        <div class="background-dialog-waning"></div>
        <div class="confirm-dialog-waning">
            <div class="confirm-dialog-name-waning">
                <span>MISA eshop</span>
                <div class="close-form-waning" @click="close"></div>
            </div>
            <div class="confirm-dialog-content-waning">
                <div class="icon-dialog-waning"></div>
                <div class="text-waning">
                    Mã khách hàng đã tồn tại. Vui lòng kiểm tra lại.
                </div>
            </div>
            <div class="confirm-dialog-buttons-waning">
                <button class="btn-dialog-waning" @click="close">
                    Hủy bỏ
                </button>
            </div>
       </div> 
    
    </div>
</template>
<script>
export default ({
    name: 'DialogStoreCodeExits',
    methods: {
        close(){
            this.$emit('closeTabWaning');
        },
    },
})
</script>

<style>
@import '../../styles/dialog/dialogStoreCodeExits.css';
</style>