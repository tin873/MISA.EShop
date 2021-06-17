<template>
    <div class="delete-dialog">
        <div class="background-dialog"></div>
        <div class="confirm-dialog">
            <div class="confirm-dialog-name">
                <span>Xóa dữ liệu</span>
                <div class="close-form" @click="close"></div>
            </div>
            <div class="confirm-dialog-content">
                <div class="icon-dialog"></div>
                <div class="text">
                    Bạn có chắc chắn muốn xóa
                    <span class="store-name">{{
                    this.store.storeName
                    }}</span>
                    khỏi danh sách cửa hàng.
                </div>
            </div>
            <div class="confirm-dialog-buttons">
                <button class="btn-dialog btn-delete" @click="deleteStore">
                 <img src="../../assets/icon/delete-white.png" />
                    Xóa
                </button>
                <button class="btn-dialog btn-cancel" @click="close">
                <span></span>
                    Hủy bỏ
                </button>
            </div>
       </div> 
    
    </div>
</template>
<script>
import axios from "axios";
export default ({
    name: 'ComfirmDelete',
    methods: {
        close(){
            this.$emit('closeDialog');
        },
        deleteStore(){
            this.delete(this.store.storeId).then(this.load());
        },
        //load laij
        load(){
            this.$emit("pageChanged", 1);
        },
        //call api xoas 
        async delete(id){
            try{
                var url = `${this.$Const.API_HOST}/api/v1/Stores/${id}`;
                var response = await axios.delete(url);
                if(response.data.data == 1)
                {
                    this.close();
                }
            }catch(error){
                console.log(error);
            }
        }
    },
    computed:{
        store(){
            return this.$store.getters.getDataRow;
        },
    },
})
</script>

<style>
@import '../../styles/dialog/comfirmDelete.css';
</style>