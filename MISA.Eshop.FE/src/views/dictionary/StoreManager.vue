<template>
    <div class="view-store">
        <div class="header-features">
            <div class="btn add-btn hover-pointer" @click="addStore()">
                <div class="icon-header icon-add"></div>
                <div class="item-name-content">Thêm mới</div>
            </div>
            <div class="btn btn-borderleft hover-pointer">
                <div class="icon-header icon-replic"></div>
                <div class="item-name-content">Nhân bản</div>
            </div>
            <div class="btn btn-borderleft hover-pointer">
                <div class="icon-header icon-edit"></div>
                <div class="item-name-content">Sửa</div>
            </div>
            <div class="btn btn-borderleft hover-pointer">
                <div class="icon-header icon-delete"></div>
                <div class="item-name-content">Xóa</div>
            </div>
            <div class="btn btn-borderleft hover-pointer">
                <div class="icon-header icon-load"></div>
                <div class="item-name-content">Nạp</div>
            </div>
        </div>
        <div class="content-grid">
            <table class="table-asset" id="idtableAsset">
                <colgroup>
                    <col width = "159" />
                    <col width = "249"/>
                    <col width = "983"/>
                    <col width = "129"/>
                    <col width = "149"/>
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
                                <option value="1">oke</option>
                            </select>
                        </div>
                    </th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="store in listStore"
                    :key="store.StoreId">
                        <td>{{store.StoreCode}}</td>
                        <td>{{store.StoreName}}</td>
                        <td>{{store.Address}}</td>
                        <td>{{store.PhoneNumber}}</td>
                        <td>{{store.Status}}</td>
                    </tr>
                </tbody>
            </table>
            <Toolbar/>
        </div>
        <Detail @closeTab="closeTab" v-if="isShowDetail"/>
    </div>
</template>
<script>
import Toolbar from "../../components/common/Toolbar.vue";
import Detail from "./StoreDetail.vue";
export default ({
    name: 'StoreManager',
    components:{
        Toolbar,
        Detail,
    },
    methods: {
        addStore(){
            var me = this;
            me.$store.commit("showDetailStore");
        },
        closeTab(){
            console.log("2");
            var me = this;
            me.$store.commit("showDetailStore");
        },
    },
    computed: {
        isShowDetail(){
            return this.$store.getters.getIsShow;
        }
    },
    data() {
        return{
            listStore: [
                {
                    StoreId: '23423kdfkd3',
                    StoreCode: 'mskc3s',
                    StoreName: 'ákdei32',
                    Address: 'Tan lap dan phuong ha noi',
                    PhoneNumber: '035656797',
                    Status: 'hoat dong',
                },
                {
                    StoreId: '23423kdfkd3',
                    StoreCode: 'mskc3s',
                    StoreName: 'ákdei32',
                    Address: 'Tan lap dan phuong ha noi',
                    PhoneNumber: '035656797',
                    Status: 'hoat dong',
                },
                {
                    StoreId: '23423kdfkd3',
                    StoreCode: 'mskc3s',
                    StoreName: 'ákdei32',
                    Address: 'Tan lap dan phuong ha noi',
                    PhoneNumber: '035656797',
                    Status: 'hoat dong',
                },
                {
                    StoreId: '23423kdfkd3',
                    StoreCode: 'mskc3s',
                    StoreName: 'ákdei32',
                    Address: 'Tan lap dan phuong ha noi',
                    PhoneNumber: '035656797',
                    Status: 'hoat dong',
                }
            ],
        }
    }
})
</script>
<style scoped>
@import '../../styles/dictionary/storeManagerment.css';
</style>
