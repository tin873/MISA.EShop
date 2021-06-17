<template>
    <div class="modal">
        <div class="modal-background"></div>
        <div class="modal-content">
            <div class="modal-header">
                <div class="header-title">{{titleModel}}</div>
                <div class="icon-modal icon-close" @click="close()"></div>
            </div>
            <div class="modal-body">
                <div class="modal-item">
                    <div class="modal-item-name">Mã cửa hàng<span>*</span></div>
                    <div class="model-item-input">
                        <input v-model="store.storeCode" class="validate-input mgr-5" type="text"/>
                        <div class="icon-error isActive"></div>
                    </div>
                </div>
                <div class="modal-item">
                    <div class="modal-item-name">Tên cửa hàng<span>*</span></div>
                    <div class="model-item-input">
                        <input v-model="store.storeName" class="validate-input mgr-5" type="text"/>
                        <div class="icon-error isActive"></div>
                    </div>
                </div>
                <div class="modal-item-special">
                    <div class="modal-item-name">Địa chỉ<span>*</span></div>
                    <div class="model-item-input">
                        <textarea v-model="store.address" class="validate-textarea mgr-5" type="text"/>
                        <div class="icon-error isActive"></div>
                    </div>
                </div>
                <div class="modal-item">
                    <div class="double-item">
                        <div class="modal-item-name">Số điện thoại</div>
                        <input v-model="store.phoneNumber" class="validate-input-sort" type="text"/>
                    </div>
                    <div class="double-item">
                        <div class="modal-item-name">Mã số thuế</div>
                        <input v-model="store.storeTaxCode" class="validate-input-sort" type="text"/>
                    </div>
                </div>
                <div class="modal-item">
                    <div class="double-item">
                        <div class="modal-item-name">Quốc gia</div>
                        <div class="cellcal-flex">
                            <div class="combobox-model">
                            <input type="text" id="inputCountry" 
                            v-model="countryName" placeholder="chọn quốc gia" 
                            @input="onSearchCountry($event.target.value)" 
                            class="input-custom-cbb"/>
                            <button class="btn-cbb icon-down" @click="showDropCountry" />
                        </div>
                        <!-- buid item-->
                        <div class="flex-item" :class="{isActiveCbb: isActive}">
                            <div :class="{activeItem: item.countryId == countryId}" 
                            v-for="item in listItemCountry" 
                            :key="item.countryId" 
                            class="item"
                             @click="selectItemCountry(item.countryId,item.countryName)">
                             {{item.countryName}}
                             </div>
                        </div>
                        </div>
                    </div>
                </div>
                <div class="modal-item">
                    <div class="double-item">
                        <div class="modal-item-name">Tỉnh/Thành phố</div>
                        <div class="cellcal-flex">
                            <div class="combobox-model">
                            <input type="text" id="inputProvince" 
                            v-model="provinceName" 
                            placeholder="chọn thành phố" 
                            @input="onSearchProvince($event.target.value)"  
                            class="input-custom-cbb"/>
                            <button class="btn-cbb icon-down" 
                            @click="showDropProvince" />
                        </div>
                        <!-- buid item-->
                        <div class="flex-item" 
                        :class="{isActiveCbb: isActiveProvince}">
                            <div :class="{activeItem: item.provinceId == provinceId}" 
                            v-for="item in listItemProvince" 
                            :key="item.provinceId" class="item" 
                            @click="selectItemProvince(item.provinceId,item.provinceName)">
                            {{item.provinceName}}
                            </div>
                        </div>
                        </div>
                    </div>
                    <div class="double-item">
                        <div class="modal-item-name">Quận/Huyện</div>
                        <div class="cellcal-flex">
                            <div class="combobox-model">
                            <input type="text" id="inputDistrict" 
                            v-model="districtName" 
                            placeholder="chọn Quận/Huyện" 
                            @input="onSearchDistrict($event.target.value)"  
                            class="input-custom-cbb"/>
                            <button class="btn-cbb icon-down" 
                            @click="showDropDistrict" />
                        </div>
                        <!-- buid item-->
                        <div class="flex-item" :class="{isActiveCbb: isActiveDistrict}">
                            <div :class="{activeItem: item.districtId == districtId}" 
                            v-for="item in listItemDistrict" 
                            :key="item.districtId" class="item" 
                            @click="selectItemDistrict(item.districtId,item.districtName)">
                            {{item.districtName}}
                            </div>
                        </div>
                        </div>
                    </div>
                </div>
                <div class="modal-item">
                    <div class="double-item">
                        <div class="modal-item-name">Phường/Xã</div>
                        <div class="cellcal-flex">
                            <div class="combobox-model">
                            <input type="text" id="inputWard" 
                            v-model="wardName" placeholder="chọn Xã/Phường" 
                            @input="onSearchWard($event.target.value)"  class="input-custom-cbb"/>
                            <button class="btn-cbb icon-down" 
                            @click="showDropWard" />
                        </div>
                        <!-- buid item-->
                        <div class="flex-item" :class="{isActiveCbb: isActiveWard}">
                            <div :class="{activeItem: item.wardId == wardId}" 
                            v-for="item in listItemWard" 
                            :key="item.wardId" class="item" 
                            @click="selectItemWard(item.wardId,item.wardName)">
                            {{item.wardName}}
                            </div>
                        </div>
                        </div>
                    </div>
                    <div class="double-item">
                        <div class="modal-item-name">Đường Phố</div>
                        <input v-model="store.street" class="validate-input-sort mgr-5" type="text"/>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <div class="footer-left">
                    <button class="btn-footer-help hover-pointer">
                        <div class="icon-footer-help"></div>
                        <div class="item-footer-name">Trợ giúp</div>
                    </button>
                </div>
                <div class="footer-right">
                    <button class="btn-footer-save mgr-8 hover-pointer">
                        <div class="icon-footer-save"></div>
                        <div class="item-footer-save">Lưu</div>
                    </button>
                    <button class="btn-footer-add-save mgr-8 hover-pointer" @click="addNewStore">
                        <div class="icon-footer-add"></div>
                        <div class="item-footer-name-add">Lưu và thêm mới</div>
                    </button>
                    <button class="btn-footer-cancel hover-pointer" @click="close()">
                        <div class="icon-footer-cancel"></div>
                        <div class="item-footer-name-cancel">Hủy bỏ</div>
                    </button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import axios from "axios";

export default ({
    name: 'StoreDetail',
    props: ['titleModel', 'rowData'],
    computed:{
        store(){
            return this.$store.getters.getDataRow;
        },
    },
    created(){
        //lấy thông tin quốc gia
        this.getCountry();
        this.getAddress();
    },
    methods: {
        //thêm mới bản ghi
        addNewStore(){
            this.store.countryId = this.countryId;
            this.store.provinceId = this.provinceId;
            this.store.districtId = this.districtId;
            this.store.wardId = this.wardId;
            this.store.status = true;
            this.fsave().then(this.load());
        },
        //load laij trang
        load(){
            this.$emit("pageChanged", 1);
        },
        //thực hiện thêm hoặc sửa
        async fsave(){
            var url = "";
            if(this.store.storeId != null)
            {
                //sửa thông tin
                console.log("Sửa");
                try{
                    url = `${this.$Const.API_HOST}/api/v1/Stores/${this.store.storeId}`;
                    let response = await axios.put(url, this.store);
                    if(response.data.data == 1)
                    {
                        this.close();
                    }
                }
                catch(error){
                    console.log(error);
                }
            }
            else
            {
                //thêm mới
                try{
                    console.log(this.store);
                    console.log("Thêm mới");
                    url = `${this.$Const.API_HOST}/api/v1/Stores`;
                    let response = await axios.post(url, this.store);
                    console.log(response);
                    if(response.data.data == 1)
                    {
                        this.close();
                    }
                }catch(error){
                    console.log(error);
                }
            }
        },
        //kiểm tra mã cửa hàng
        async checkStoreCodeExist(storeCode){
            try{
                var url=`${this.$Const.API_HOST}/api/v1/Stores/check/${storeCode}`;
                var res = await axios.get(url);
                return res.data.data;
            }catch(error){
                console.console.warn(error);
            }
        },
        //lấy tên quốc gia
        getAddress(){
            var store = this.store
            if(store != null)
            {
                this.getCountryName(store.countryId);
                this.getProvinceName(store.provinceId);
                this.getDistrictName(store.districtId);
                this.getWardName(store.wardId);
            }
        },
        async getCountryName(id){
            var url = `${this.$Const.API_HOST}/api/v1/Countrys/${id}`;
            await axios.get(url)
                       .then(response =>{
                            this.countryName = response.data.data.countryName;
                            this.countryId = response.data.data.countryId;
                       }).catch(err => {
                           console.log(err);
                       });
            if(this.store.countryId != null)
            {
                this.getProvince(id);
            }
        },
        async getProvinceName(id){
            var url = `${this.$Const.API_HOST}/api/v1/Provinces/${id}`;
            await axios.get(url)
                       .then(response =>{
                            this.provinceName = response.data.data.provinceName;
                            this.provinceId = response.data.data.provinceId;
                       }).catch(err => {
                           console.log(err);
                       });
            if(this.store.provinceId != null)
            {
                this.getDistrict(id);
            }
        },
        async getDistrictName(id){
            var url = `${this.$Const.API_HOST}/api/v1/Districts/${id}`;
            await axios.get(url)
                       .then(response =>{
                            this.districtName = response.data.data.districtName;
                            this.districtId = response.data.data.districtId;
                       }).catch(err => {
                           console.log(err);
                       });
            if(this.store.districtId != null)
            {
                this.getWard(id);
            }
        },
        async getWardName(id){
            var url = `${this.$Const.API_HOST}/api/v1/Wards/${id}`;
            await axios.get(url)
                       .then(response =>{
                            this.wardName = response.data.data.wardName;
                            this.wardId = response.data.data.wardId;
                       }).catch(err => {
                           console.log(err);
                       });
        },
        //đóng cửa sổ
        close(){
            this.$emit('closeTab');
        },
        //country///////////
        //hiện danh sách các quốc gia
        showDropCountry(){
            this.isActive = !this.isActive;
            this.listItemCountry = this.listCountry;   
            document.getElementById("inputCountry").focus();
        },
        //tìm kiếm quốc gia
        onSearchCountry(value){
            //nếu không có giá trị thì không hiện
            this.countryId = null;
            if(value == "")
            {
                this.isActive = false;
            }
            else
            {
                this.listItemCountry = this.listCountry.filter(lists => lists.countryName.toLowerCase().includes(value.toLowerCase()));
                if(this.listItemCountry != null)
                {
                    this.isActive = true;
                }
            }
        },
        selectItemCountry(id, name){
            this.countryName = name;
            this.countryId = id;
            this.isActive = !this.isActive;
            this.getProvince(id);
            this.provinceName = null;
            this.provinceId = null;
            this.districtName = null;
            this.districtId = null;
            this.wardName = null;
            this.wardId = null;
            document.getElementById("inputCountry").focus();
        },
        //lấy danh sách quốc gia
        async getCountry(){
            var url = `${this.$Const.API_HOST}/api/v1/Countrys`;
            await axios.get(url)
                       .then(response =>{
                           this.listCountry = response.data.data;
                       }).catch(err => {
                           console.log(err);
                       });
        },
        //country////
        //province
        onSearchProvince(value){
            //nếu không có giá trị thì không hiện
            this.provinceId = null;
            if(value == "")
            {
                this.isActiveProvince = false;
            }
            else
            {
                this.listItemProvince = this.listProvince.filter(lists => lists.provinceName.toLowerCase().includes(value.toLowerCase()));
                if(this.listItemProvince != null)
                {
                    this.isActiveProvince = true;
                }
            }
        },
        showDropProvince(){
            this.isActiveProvince = !this.isActiveProvince;
            this.listItemProvince = this.listProvince; 
            document.getElementById("inputProvince").focus();
        },
        selectItemProvince(id, name){
            this.provinceName = name;
            this.provinceId = id;
            this.isActiveProvince = !this.isActiveProvince;
            this.getDistrict(id);
            this.districtName = null;
            this.districtId = null;
            this.wardName = null;
            this.wardId = null;
            document.getElementById("inputProvince").focus();
        },
        //lấy danh sách thành phố từ quốc gia
        async getProvince(id){
            var url = `${this.$Const.API_HOST}/api/v1/Provinces/GetProvincetWithCountry/${id}`;
            await axios.get(url)
                       .then(response =>{
                           this.listProvince = response.data.data;
                       }).catch(err => {
                           console.log(err);
                       });
        },
        //District////
        //district
        onSearchDistrict(value){
            this.districtId = null;
            //nếu không có giá trị thì không hiện
            if(value == "")
            {
                this.isActiveDistrict = false;
            }
            else
            {
                this.listItemDistrict = this.listDistrict.filter(lists => lists.districtName.toLowerCase().includes(value.toLowerCase()));
                if(this.listItemDistrict != null)
                {
                    this.isActiveDistrict = true;
                }
            }
        },
        showDropDistrict(){
            this.isActiveDistrict = !this.isActiveDistrict;
            this.listItemDistrict = this.listDistrict; 
            document.getElementById("inputDistrict").focus();
        },
        selectItemDistrict(id, name){
            this.districtName = name;
            this.districtId = id;
            this.isActiveDistrict = !this.isActiveDistrict;
            this.getWard(id);
            this.wardName = null;
            this.wardId = null;
            document.getElementById("inputDistrict").focus();
        },
        //lấy danh sách Quận huyện từ thành phố
        async getDistrict(id){
            var url = `${this.$Const.API_HOST}/api/v1/Districts/GetDistrictWithProvince/${id}`;
            await axios.get(url)
                       .then(response =>{
                           this.listDistrict = response.data.data;
                       }).catch(err => {
                           console.log(err);
                       });
        },

        //Ward////
        //ward
        onSearchWard(value){
            this.wardId = null;
            //nếu không có giá trị thì không hiện
            if(value == "")
            {
                this.isActiveWard = false;
            }
            else
            {
                this.listItemWard = this.listWard.filter(lists => lists.wardName.toLowerCase().includes(value.toLowerCase()));
                if(this.listItemWard != null)
                {
                    this.isActiveWard = true;
                }
            }
        },
        showDropWard(){
            this.isActiveWard = !this.isActiveWard;
            this.listItemWard = this.listWard; 
            document.getElementById("inputWard").focus();
        },
        selectItemWard(id, name){
            this.wardName = name;
            this.wardId = id;
            this.isActiveWard = !this.isActiveWard;
            document.getElementById("inputWard").focus();
        },
        //lấy danh sách Quận huyện từ thành phố
        async getWard(id){
            var url = `${this.$Const.API_HOST}/api/v1/Wards/GetWardWithDistrict/${id}`;
            await axios.get(url)
                       .then(response =>{
                           this.listWard = response.data.data;
                       }).catch(err => {
                           console.log(err);
                       });
        },
    },
    data(){
        return{
            //Country
            listItemCountry: [],
            listCountry: [],
            isActive: false,
            countryName: null,
            countryId: null,
            //provice
            provinceName: null,
            provinceId: null,
            isActiveProvince: false,
            listItemProvince: [],
            listProvince: [],
            //District
            districtName: null,
            districtId: null,
            isActiveDistrict: false,
            listItemDistrict: [],
            listDistrict: [],
            //ward
            wardName: null,
            wardId: null,
            isActiveWard: false,
            listItemWard: [],
            listWard: [],
        }
    },
})
</script>

<style scoped>
@import '../../styles/dictionary/storeDetail.css';
</style>
