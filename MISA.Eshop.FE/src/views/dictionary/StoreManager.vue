<template>
    <div class="view-store">
        <div class="header-features">
            <div class="btn add-btn hover-pointer" @click="addStore">
                <div class="icon-header icon-add"></div>
                <div class="item-name-content">Thêm mới</div>
            </div>
            <div class="btn btn-borderleft hover-pointer">
                <div class="icon-header icon-replic"></div>
                <div class="item-name-content">Nhân bản</div>
            </div>
            <div class="btn btn-borderleft hover-pointer" @click="editStore">
                <div class="icon-header icon-edit"></div>
                <div class="item-name-content">Sửa</div>
            </div>
            <div class="btn btn-borderleft hover-pointer">
                <div class="icon-header icon-delete"></div>
                <div class="item-name-content">Xóa</div>
            </div>
            <div class="btn btn-borderleft hover-pointer" @click="refresh">
                <div class="icon-header icon-load"></div>
                <div class="item-name-content">Nạp</div>
            </div>
        </div>
        <div class="content-grid">
            <table class="table-asset" id="idtableAsset">
                <colgroup>
                    <col width = "174" />
                    <col width = "264"/>
                    <col width = "990"/>
                    <col width = "141"/>
                    <col width = "155"/>
                </colgroup>
                <thead>
                    <tr>
                    <th>
                        <div class="name-col">Mã cửa hàng</div>
                        <div class="filter">
                            <button class="btn-gird"><span class="text-button">*</span></button>
                            <input class="input-filter input-code" type="text"/>
                        </div>
                    </th>
                    <th>
                        <div class="name-col">Tên cửa hàng</div>
                        <div class="filter">
                            <button class="btn-gird"><span class="text-button">*</span></button>
                            <input class="input-filter input-name" type="text"/>
                        </div>
                    </th>
                    <th>
                        <div class="name-col">Địa chỉ</div>
                        <div class="filter">
                            <button class="btn-gird"><span class="text-button">*</span></button>
                            <input class="input-filter input-address" type="text"/>
                        </div>
                    </th>
                    <th>
                        <div class="name-col">Số điện thoại</div>
                        <div class="filter">
                            <button class="btn-gird"><span class="text-button">*</span></button>
                            <input class="input-filter input-phone" type="text"/>
                        </div>
                    </th>
                    <th>
                        <div class="name-col">Trạng thái</div>
                        <div class="filter">
                            <button class="btn-gird"><span class="text-button">*</span></button>
                            <select class="select-head-gird" name="" id="">
                                <option selected value="2">Tất cả</option>
                                <option value="0">Đang hoạt động</option>
                                <option value="1">Dừng hoạt động</option>
                            </select>
                        </div>
                    </th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="store in listStore"
                    :key="store.storeId"
                    :class="{isSelectrow: rowDataActive.storeId == store.storeId}"
                    @click="rowClick(store)">
                        <td>{{store.storeCode}}</td>
                        <td>{{store.storeName}}</td>
                        <td>{{store.address}}</td>
                        <td>{{store.phoneNumber}}</td>
                        <td>{{store.status}}</td>
                    </tr>
                </tbody>
            </table>
            <Toolbar :totalPage="totalPage"
                    :totalRecord="totalRecord"
                    :curentPage="curentPage"
                    @pageChanged="onPageChange"/>
        </div>
        <Detail @closeTab="closeTab" v-if="isShowDetail" :titleModel="titleModel" />
    </div>
</template>
<script>
import Toolbar from "../../components/common/Toolbar.vue";
import Detail from "./StoreDetail.vue";
import axios from "axios";
export default ({
    name: 'StoreManager',
    components:{
        Toolbar,
        Detail,
    },
    created(){
        this.onLoadStore();
    },
    methods: {
        refresh(){
            this.onPageChange(1);
        },
        rowClick(value){
            this.rowDataActive = value;
        },
        addStore(){
            this.setRowData(this.rowData);
            this.titleModel = "Thêm mới cửa hàng";
            this.$store.commit("showDetailStore");
        },
        //sửa cưa hàng
        editStore(){
            this.titleModel = "Sửa cửa hàng";
            this.setRowData(this.rowDataActive);
            this.$store.commit("showDetailStore");
        },
        //lưu rowdata vào store
        setRowData(data){
            this.$store.commit("setDataRow", data);
        },
        /*
        * đóng model
        */
        closeTab(){
            var me = this;
            me.$store.commit("showDetailStore");
        },
        /*
        * call api lấy thông tin cửa hàng
        */
        async onPageChange(page){
            var pageIndex = page;
            this.curentPage = page;
            var url = `${this.$Const.API_HOST}/api/v1/Stores/Paging?pageSize=${this.pageSize}&pageIndex=${pageIndex}`;
            console.log(url);
            await axios.get(url)
                       .then(response =>{
                           this.listStore = response.data.data;
                           this.totalPage = response.data.totalPage;
                           this.totalRecord = response.data.totalRecord;
                       }).catch(err => {
                           console.log(err);
                       });
            this.rowDataActive = this.listStore[0];
        },
        /*
        * load thông tin cửa hàng khi vào trang
        */
        onLoadStore(){
            this.onPageChange(1);
        },
        //lấy giá trị dòng đầu

    },
    computed: {
        /*
        *lấy giá trị hiển thị model
        */
        isShowDetail(){
            return this.$store.getters.getIsShow;
        },
        /*
        *lấy kích thước trang
        */
        pageSize(){
            return this.$store.getters.getPageSize;
        },

    },
    data() {
        return{
            listStore: [
            ],
            rowDataActive:{},
            rowData:{},
            totalPage:0,
            totalRecord:0,
            curentPage: 1,
            titleModel: "",

        }
    }
})
</script>
<style scoped>
@import '../../styles/dictionary/storeManagerment.css';
</style>
