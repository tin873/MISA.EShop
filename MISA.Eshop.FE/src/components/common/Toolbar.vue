<template>
    <div class="toolbar">
        <div class="feature-page">
            <button class="icon-toolbar icon-page-first mgr-5"
                @click="onClickFirstPage"
                :disabled="isInFirstPage">
            </button>
            <button class="icon-toolbar icon-preview mgr-5"
                @click="onClickPreviewPage"
                :disabled="isInFirstPage">
            </button>
            <div class="page-name mgr-5">Trang</div>
            <input class="input-toolbar mgr-5" v-model="curentPage" type="text" />
            <div class="page-name mgr-5">trên {{totalPage}}</div>
            <button class="icon-toolbar icon-next mgr-5"
                @click="onClickNextPage"
                :disabled="isInLastPage">
            </button>
            <button class="icon-toolbar icon-last mgr-5"
                @click="onClickLastPage"
                :disabled="isInLastPage">
            </button>
            <button class="icon-toolbar icon-refresh mgr-5" @click="refresh"></button>
            <select @change="onClickPageSize(1,$event.target.value)"  class="select-toolbar" name="" id="">
                <option value="50">50</option>
                <option value="40">40</option>
                <option value="30">30</option>
                <option value="20">20</option>
                <option value="10" selected>10</option>
            </select>
        </div>
        <div class="toolbar-text">
            Hiển thị 1-11 trên 11 kết quả
        </div>
    </div>
</template>
<script>
export default ({
    name: 'Toolbar',
    props: {
        totalPage: {
            type: Number,
        },
        totalRecord: {
            type: Number,
        },
        curentPage: {
            type: Number,
        },
    },
    computed: {
        //xác định vị trí ở đầu trang
        isInFirstPage(){
            return this.curentPage === 1;
        },
        //xác định vị trí ở cuối trang
        isInLastPage(){
            return this.curentPage === this.totalPage;
        },

        pagesize(){
            return this.$store.getters.getPageSize;
        }
    },
    methods: {
        /*
        *chuyển về trang đầu tiên
        */
        onClickFirstPage(){
            this.$emit("pageChanged", 1);
        },
        /*
        *lùi về 1 trang
        */
        onClickPreviewPage(){
            this.$emit("pageChanged", this.curentPage-1);
        },
        /*
        *tiến lên 1 trang
        */
        onClickNextPage(){
            this.$emit("pageChanged", this.curentPage+1);
        },
        /*
        *chuyển về trang cuối
        */
        onClickLastPage(){
            this.$emit("pageChanged", this.totalPage);
        },
        /*
        *thay đổi số lượng bản ghi 1 trang
        */
        onClickPageSize(page, size){
            if(size){
                this.$store.commit("setPageSize", size)
            }
            this.$emit("pageChanged", page);
        },
        //loadlij
        refresh(){
            this.$emit("pageChanged", 1);
        },
    }
})
</script>
<style scoped>
@import '../../styles/common/toolbar.css';
</style>
