<template>
  <div class="modal">
    <div class="modal-background"></div>
    <div class="modal-content">
      <div class="modal-header">
        <div class="header-title">{{ titleModel }}</div>
        <div class="icon-modal icon-close" @click="closeTapAndSave"></div>
      </div>
      <div class="modal-body">
        <div class="modal-item">
          <div class="modal-item-name">Mã cửa hàng<span>*</span></div>
          <div class="model-item-input">
            <input
              ref="forcusFirst"
              class="validate-input mgr-5"
              type="text"
              :class="{ error: isActiveError }"
              v-model="store.storeCode"
              @input="requireStoreCode"
              @blur="requireStoreCode"
              tabindex="1"
            />
            <div
              class="icon-error .hover-pointer show-error"
              :class="{ isActive: isActiveError }"
            >
              <ul class="x-list-error" :class="{isShowError: isShowErrorStoreCode}">
                <li>Trường này không được để trống!</li>
              </ul>
            </div>
          </div>
        </div>
        <div class="modal-item">
          <div class="modal-item-name">Tên cửa hàng<span>*</span></div>
          <div class="model-item-input">
            <input
              v-model="store.storeName"
              :class="{ error: isActiveErrorStoreName }"
              @input="RequireStoreName"
              @blur="RequireStoreName"
              class="validate-input mgr-5"
              type="text"
              tabindex="2"
            />
            <div
              class="icon-error .hover-pointer show-error"
              :class="{ isActive: isActiveErrorStoreName }"
              v-bind:title="titleErrorName"
            >
              <ul class="x-list-error" :class="{isShowError: isShowErrorStoreName}">
                <li>Trường này không được để trống!</li>
              </ul>
            </div>
          </div>
        </div>
        <div class="modal-item-special">
          <div class="modal-item-name">Địa chỉ<span>*</span></div>
          <div class="model-item-input">
            <textarea
              v-model="store.address"
              :class="{ error: isActiveErrorAddress }"
              @input="RequireAddress"
              @blur="RequireAddress"
              class="validate-textarea mgr-5"
              type="text"
              tabindex="3"
            />
            <div
              class="icon-error .hover-pointer show-error"
              :class="{ isActive: isActiveErrorAddress }"
              v-bind:title="titleErrorAddress"
            >
              <ul class="x-list-error" :class="{isShowError: isShowErrorAddress}">
                <li>Trường này không được để trống!</li>
              </ul>
            </div>
          </div>
        </div>
        <div class="modal-item">
          <div class="double-item">
            <div class="modal-item-name">Số điện thoại</div>
            <div class="input-error">
              <input
                v-model="store.phoneNumber"
                :class="{ error: isActiveErrorPhone }"
                class="validate-input-sort"
                type="text"
                @input="validatePhoneNumber($event.target.value)"
                tabindex="4"
              />
              <div
                class="icon-error .hover-pointer show-error-valid"
                :class="{ isActive: isActiveErrorPhone }"
              >
                <ul class="x-list-error-valid" :class="{isShowError: isShowErrorPhone}">
                  <li>Giá trị không hợp lệ!</li>
                </ul>
              </div>
            </div>
          </div>
          <div class="double-item">
            <div class="modal-item-name">Mã số thuế</div>
            <div class="input-error">
              <input
                v-model="store.storeTaxCode"
                class="validate-input-sort"
                type="text"
                tabindex="5"
              />
            </div>
          </div>
        </div>
        <div class="modal-item">
          <div class="double-item">
            <div class="modal-item-name">Quốc gia</div>
            <div class="cellcal-flex">
              <div class="combobox-model">
                <input
                  type="text"
                  id="inputCountry"
                  v-model="countryName"
                  placeholder="chọn quốc gia"
                  @input="onSearchCountry($event.target.value)"
                  :class="{ error: isActiveErrorCountry }"
                  @blur="checkValueCountry"
                  class="input-custom-cbb"
                  tabindex="6"
                />
                <button
                  class="btn-cbb icon-down"
                  @click="showDropCountry"
                  :class="{ setMargin: isActiveErrorCountry }"
                />
                <div
                  class="icon-error .hover-pointer show-error-valid"
                  :class="{ isActive: isActiveErrorCountry }"
                  v-bind:title="titleErrorCountry"
                >
                <ul class="x-list-error-valid" :class="{isShowError: isShowErrorCountry}">
                  <li>Giá trị không hợp lệ!</li>
                </ul>
                </div>
              </div>
              <!-- buid item-->
              <div
                class="flex-item"
                :class="{
                  isActiveCbb: isActive,
                  isActiveCbbWidth: isActiveErrorCountry,
                }"
              >
                <div
                  :class="{
                    activeItem: item.countryId == countryId,
                    setWith: isActiveErrorCountry,
                  }"
                  v-for="item in listItemCountry"
                  :key="item.countryId"
                  class="item"
                  @click="selectItemCountry(item.countryId, item.countryName)"
                >
                  {{ item.countryName }}
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
                <input
                  type="text"
                  id="inputProvince"
                  v-model="provinceName"
                  placeholder="chọn thành phố"
                  @input="onSearchProvince($event.target.value)"
                  :class="{ error: isActiveErrorProvince }"
                  @blur="checkValueProvince"
                  class="input-custom-cbb"
                  tabindex="7"
                />
                <button
                  class="btn-cbb icon-down"
                  @click="showDropProvince"
                  :class="{ setMargin: isActiveErrorProvince }"
                />
                <div
                  class="icon-error .hover-pointer show-error-valid"
                  :class="{ isActive: isActiveErrorProvince }"
                  v-bind:title="titleErrorProvince"
                >
                <ul class="x-list-error-valid" :class="{isShowError: isShowErrorProvince}">
                  <li>Giá trị không hợp lệ!</li>
                </ul>
                </div>
              </div>
              <!-- buid item-->
              <div
                class="flex-item"
                :class="{
                  isActiveCbb: isActiveProvince,
                  isActiveCbbWidth: isActiveErrorProvince,
                }"
              >
                <div
                  :class="{
                    activeItem: item.provinceId == provinceId,
                    setWith: isActiveErrorProvince,
                  }"
                  v-for="item in listItemProvince"
                  :key="item.provinceId"
                  class="item"
                  @click="
                    selectItemProvince(item.provinceId, item.provinceName)
                  "
                >
                  {{ item.provinceName }}
                </div>
              </div>
            </div>
          </div>
          <div class="double-item">
            <div class="modal-item-name">Quận/Huyện</div>
            <div class="cellcal-flex">
              <div class="combobox-model">
                <input
                  type="text"
                  id="inputDistrict"
                  v-model="districtName"
                  placeholder="chọn Quận/Huyện"
                  @input="onSearchDistrict($event.target.value)"
                  :class="{ error: isActiveErrorDistrict }"
                  @blur="checkValueDistrict"
                  class="input-custom-cbb"
                  tabindex="8"
                />
                <button
                  class="btn-cbb icon-down"
                  @click="showDropDistrict"
                  :class="{ setMargin: isActiveErrorDistrict }"
                />
                <div
                  class="icon-error .hover-pointer show-error"
                  :class="{ isActive: isActiveErrorDistrict }"
                  v-bind:title="titleErrorProvince"
                >
                <ul class="x-list-error" :class="{isShowError: isShowErrorDistrict}">
                  <li>Giá trị không hợp lệ!</li>
                </ul>
                </div>
              </div>
              <!-- buid item-->
              <div
                class="flex-item"
                :class="{
                  isActiveCbb: isActiveDistrict,
                  isActiveCbbWidth: isActiveErrorDistrict,
                }"
              >
                <div
                  :class="{
                    activeItem: item.districtId == districtId,
                    setWith: isActiveDistrict,
                  }"
                  v-for="item in listItemDistrict"
                  :key="item.districtId"
                  class="item"
                  @click="
                    selectItemDistrict(item.districtId, item.districtName)
                  "
                >
                  {{ item.districtName }}
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
                <input
                  type="text"
                  id="inputWard"
                  v-model="wardName"
                  placeholder="chọn Xã/Phường"
                  @input="onSearchWard($event.target.value)"
                  :class="{ error: isActiveErrorWard }"
                  @blur="checkValueWard"
                  class="input-custom-cbb"
                  tabindex="9"
                />
                <button
                  class="btn-cbb icon-down"
                  @click="showDropWard"
                  :class="{ setMargin: isActiveErrorWard }"
                />
                <div
                  class="icon-error .hover-pointer show-error-valid"
                  :class="{ isActive: isActiveErrorWard }"
                  v-bind:title="titleErrorProvince"
                >
                <ul class="x-list-error-valid" :class="{isShowError: isShowErrorWard}">
                  <li>Giá trị không hợp lệ!</li>
                </ul>
                </div>
              </div>
              <!-- buid item-->
              <div
                class="flex-item"
                :class="{
                  isActiveCbb: isActiveWard,
                  isActiveCbbWidth: isActiveErrorWard,
                }"
              >
                <div
                  :class="{
                    activeItem: item.wardId == wardId,
                    setWith: isActiveWard,
                  }"
                  v-for="item in listItemWard"
                  :key="item.wardId"
                  class="item"
                  @click="selectItemWard(item.wardId, item.wardName)"
                >
                  {{ item.wardName }}
                </div>
              </div>
            </div>
          </div>
          <div class="double-item">
            <div class="modal-item-name">Đường Phố</div>
            <div class="input-error">
              <input
                v-model="store.street"
                class="validate-input-sort"
                type="text"
                tabindex="10"
              />
            </div>
          </div>
        </div>
        <div
          class="modal-item custom-height"
          :class="{ isActiveCheckbox: isEdit }"
        >
          <div class="double-item">
            <div class="modal-item-name"></div>
            <div class="checkbox light-height-custom">
              <input
                type="checkbox"
                class="checkbox-custom"
                v-model="store.status"
                tabindex="11"
              />
              Ngừng hoạt động
            </div>
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
          <button
            class="btn-footer-save mgr-8 hover-pointer"
            @click="saveStore"
          >
            <div class="icon-footer-save"></div>
            <div class="item-footer-save">Lưu</div>
          </button>
          <button
            class="btn-footer-add-save mgr-8 hover-pointer"
            @click="saveAndAddStore"
          >
            <div class="icon-footer-add"></div>
            <div class="item-footer-name-add">Lưu và thêm mới</div>
          </button>
          <button class="btn-footer-cancel hover-pointer" @click="close()">
            <div class="icon-footer-cancel"></div>
            <div class="item-footer-name-cancel">Hủy bỏ</div>
          </button>
        </div>
      </div>
      <LoadingForm v-if="isLoadingForm" />
    </div>
    <DialogStoreCodeExits
      v-if="isShowDialogWaning"
      @closeTabWaning="closeTabWaning"
    />
    <DialogSaveData
      v-if="isShowDialogSavedata"
      @closeTabSaveData="closeTabSaveData"
      @closeTabNoSave="closeTabNoSave"
      @closeTabSave="closeTabSave"
    />
  </div>
</template>

<script>
import axios from "axios";
import DialogStoreCodeExits from "../../components/dialog/DialogStoreCodeExits.vue";
import DialogSaveData from "../../components/dialog/DialogSaveData.vue";
import LoadingForm from "../../components/common/loadingForm.vue";
export default {
  name: "StoreDetail",
  props: ["titleModel", "rowData", "replicationId", "editId", "isEdit"],
  components: {
    DialogStoreCodeExits,
    DialogSaveData,
    LoadingForm,
  },
  computed: {
    store() {
      return this.$store.getters.getDataRow;
    },
    /*
     *lấy giá trị hiển thị dialog waning
     */
    isShowDialogWaning() {
      return this.$store.getters.getIsShowDialogWaning;
    },
    //lấy giá trị hiển thị dialog save data
    isShowDialogSavedata() {
      return this.$store.getters.getIsShowDialogSaveData;
    },
  },
  created() {
    //lấy thông tin quốc gia
    this.getCountry();
    //lấy thông tin quốc gia, thành phố, quận huyện, xã phường khi sửa hoặc nhân bản
    this.getAddress();
    this.cencelLoading();
  },
  mounted() {
    this.$refs.forcusFirst.focus();
  },
  methods: {
    //tắt loading form
    cencelLoading() {
      setTimeout(() => {
        this.isLoadingForm = false;
      }, 1500);
    },
    /*
     *button lưu và thêm mới
     *CreatedBy: ndtin(18/06/2021)
     */
    saveAndAddStore() {
      this.isSave = false;
      this.addNewStore();
    },
    /*
     *button thêm mới
     *CreatedBy: ndtin(18/06/2021)
     */
    saveStore() {
      this.isSave = true;
      this.addNewStore();
    },
    /*
     *Lưu dữ liệu vào DB
     *CreatedBy: ndtin(18/06/2021)
     */
    addNewStore() {
      //kiểm tra bắt buộc nhập các trường storeCode, StoreName, address
      if (
        this.store.storeCode != null &&
        this.store.storeCode != "" &&
        this.store.storeName != null &&
        this.store.storeName != "" &&
        this.store.address != null &&
        this.store.address != ""
      ) {
        //kiểm tra các trường phoneNumber, country, province, district, ward nhập đúng thông tin chưa
        if (
          !this.isActiveErrorPhone &&
          !this.isActiveErrorCountry &&
          !this.isActiveErrorProvince &&
          !this.isActiveErrorDistrict &&
          !this.isActiveErrorWard
        ) {
          //truyền id quốc gia khi chọn
          this.store.countryId = this.countryId;
          //truyền id thành phố khi chọn
          this.store.provinceId = this.provinceId;
          //truyền id quận huyện khi chọn
          this.store.districtId = this.districtId;
          //truyền id xã phường khi chọn
          this.store.wardId = this.wardId;
          //nếu thêm mới thì set hoạt động cho cửa hàng
          if (this.store.status == null) {
            this.store.status = false;
          }
          if (this.store.status) {
            this.store.status == true;
          } else {
            this.store.status == false;
          }
          //nếu nhân bản bỏ StoreId
          if (this.replicationId != "") {
            this.$delete(this.store, "storeId");
          }
          //lưu lại
          this.fsave();
          //kiểm tra xem người dùng sửa hay thêm dữ liệu mới
          if (this.editId == "") {
            //thêm dữ liệu mới không cần load trang
            this.reload();
          }
        }else{
          if(this.isActiveErrorPhone){
            this.isShowErrorPhone = true;
          setTimeout(() =>this.isShowErrorPhone = false, 1500);
          }
          if(this.isActiveErrorCountry){
            this.isShowErrorCountry = true;
          setTimeout(() => this.isShowErrorCountry = false, 1500);
          }
          if(this.isActiveErrorProvince){
            this.isShowErrorProvince = true;
          setTimeout(() => this.isShowErrorProvince = false, 1500);
          }
          if(this.isActiveErrorDistrict){
            this.isShowErrorDistrict = true;
          setTimeout(() => this.isShowErrorDistrict = false, 1500);
          }
          if(this.isActiveErrorWard){
            this.isShowErrorWard = true;
          setTimeout(() => this.isShowErrorWard = false, 1500);
          }
        }
      } else {
        if (this.store.storeCode == null || this.store.storeCode == "") {
          this.isActiveError = true;
          this.isShowErrorStoreCode = true;
          setTimeout(() => this.isShowErrorStoreCode = false, 1500);
        }
        if (this.store.storeName == null || this.store.storeName == "") {
          this.isActiveErrorStoreName = true;
          this.isShowErrorStoreName = true;
          setTimeout(() => this.isShowErrorStoreName = false, 1500);
        }
        if (this.store.address == null || this.store.address == "") {
          this.isActiveErrorAddress = true;
          this.isShowErrorAddress = true;
          setTimeout(() => this.isShowErrorAddress = false, 1500);
        }
      }
    },
    //load lại trang
    reload() {
      this.$emit("AddStoreNew", this.store);
    },
    /*
     *Thực hiện thêm mới hoặc sửa dữ liệu nhập vào
     *CreatedBy: ndtin(18/06/2021)
     */
    async fsave() {
      var url = "";
      await this.checkStoreCodeExist(this.store.storeCode);
      this.isLoadingForm = true;
      if (this.store.storeId != null && this.store.storeId != "") {
        //sửa thông tin
        try {
          if (this.store.storeCode == this.storeCodeFirst) {
            url = `${this.$Const.API_HOST}/api/v1/Stores/${this.store.storeId}`;
            let response = await axios.put(url, this.store);
            //Sửa thành công đóng cửa xổ model
            if (response.data.data == 1 && this.isSave) {
              this.isLoadingForm = false;
              this.close();
            } else {
              //kiểm tra người dùng click button Lưu hay Lưu và thêm mới
              if (response.data.data == 1 && !this.isSave) {
                this.isLoadingForm = false;
                this.refreshCombobox();
                this.$emit("addNewStore", true);
              }
            }
            this.isLoadingForm = false;
          } else {
            if (this.isCodeExits) {
              url = `${this.$Const.API_HOST}/api/v1/Stores/${this.store.storeId}`;
              let response = await axios.put(url, this.store);
              //Sửa thành công đóng cửa xổ model
              if (response.data.data == 1 && this.isSave) {
                this.isLoadingForm = false;
                this.close();
              } else {
                if (response.data.data == 1 && !this.isSave) {
                  this.isLoadingForm = false;
                  this.refreshCombobox();
                  this.$emit("addNewStore", true);
                }
              }
              this.isLoadingForm = false;
            } else {
              this.isLoadingForm = false;
              this.openWaning();
            }
          }
        } catch (error) {
          console.log(error);
          setTimeout((this.isLoadingForm = false), 4000);
        }
      } else {
        //thêm mới
        try {
          if (this.isCodeExits) {
            url = `${this.$Const.API_HOST}/api/v1/Stores`;
            let response = await axios.post(url, this.store);
            if (response.data.data == 1 && this.isSave) {
              this.close();
              this.isLoadingForm = false;
            } else {
              if (response.data.data == 1 && !this.isSave) {
                this.isLoadingForm = false;
                this.refreshCombobox();
                this.$emit("addNewStore", true);
              }
            }
            this.isLoadingForm = false;
          } else {
            this.isLoadingForm = false;
            this.openWaning();
          }
        } catch (error) {
          console.log(error);
          setTimeout((this.isLoadingForm = false), 4000);
        }
      }
    },
    /**
     *xóa dữ liệu chọn combobox
     *CreatedBy: ndtin(20/06/2021)
     */
    refreshCombobox() {
      this.countryName = null;
      this.countryId = null;
      this.provinceName = null;
      this.provinceId = null;
      this.districtName = null;
      this.districtId = null;
      this.wardName = null;
      this.wardId = null;
    },
    /*
     *Kiểm tra bắt buộc nhập trường storeCode
     *CreatedBy: ndtin(18/06/2021)
     */
    requireStoreCode() {
      let code = this.store.storeCode;
      if (code == "" || code == null) {
        this.isShowErrorStoreCode = true;
        setTimeout(() => this.isShowErrorStoreCode = false, 1500);
        this.isActiveError = true;
      } else {
        this.isActiveError = false;
      }
    },
    /*
     *Kiểm tra bắt buộc nhập trường storeName
     *CreatedBy: ndtin(18/06/2021)
     */
    RequireStoreName() {
      let name = this.store.storeName;
      if (name == "" || name == null) {
        this.isShowErrorStoreName = true;
          setTimeout(() => this.isShowErrorStoreName = false, 1500);
        this.isActiveErrorStoreName = true;
      } else {
        this.isActiveErrorStoreName = false;
      }
    },
    /*
     *Kiểm tra bắt buộc nhập trường address
     *CreatedBy: ndtin(18/06/2021)
     */
    RequireAddress() {
      let address = this.store.address;
      if (address == "" || address == null) {
        this.isShowErrorAddress = true;
          setTimeout(() => this.isShowErrorAddress = false, 1500);
        this.isActiveErrorAddress = true;
      } else {
        this.isActiveErrorAddress = false;
      }
    },
    /*
     *Kiểm tra mã cửa hàng có tồn tại không
     *CreatedBy: ndtin(18/06/2021)
     */
    async checkStoreCodeExist(storeCode) {
      try {
        var url = `${this.$Const.API_HOST}/api/v1/Stores/check/${storeCode}`;
        await axios.get(url).then((response) => {
          this.isCodeExits = response.data.data;
        });
      } catch (error) {
        console.console.warn(error);
      }
    },
    /*
     * Lấy tên quốc gia, thành phố, xã phwuowngn, quận huyện khi sửa hoặc nhân bản
     *CreatedBy: ndtin(18/06/2021)
     */
    getAddress() {
      var store = this.store;
      if (store.storeCode != null && store.storeCode != "") {
        this.storeCodeFirst = store.storeCode;
        this.getCountryName(store.countryId);
        this.getProvinceName(store.provinceId);
        this.getDistrictName(store.districtId);
        this.getWardName(store.wardId);
      }
    },
    /*
     *Call API lấy tên, mã quốc gia
     *CreatedBy: ndtin(18/06/2021)
     */
    async getCountryName(id) {
      var url = `${this.$Const.API_HOST}/api/v1/Countrys/${id}`;
      await axios
        .get(url)
        .then((response) => {
          this.countryName = response.data.data.countryName;
          this.countryId = response.data.data.countryId;
        })
        .catch((err) => {
          console.log(err);
        });
      if (this.store.countryId != null) {
        this.getProvince(id);
      }
    },
    /*
     *Call API lấy tên, mã Thành phố
     *CreatedBy: ndtin(18/06/2021)
     */
    async getProvinceName(id) {
      var url = `${this.$Const.API_HOST}/api/v1/Provinces/${id}`;
      await axios
        .get(url)
        .then((response) => {
          this.provinceName = response.data.data.provinceName;
          this.provinceId = response.data.data.provinceId;
        })
        .catch((err) => {
          console.log(err);
        });
      if (this.store.provinceId != null) {
        this.getDistrict(id);
      }
    },
    /*
     *Call api lấy tên, mã quận huyện
     *CreatedBy: ndtin(18/06/2021)
     */
    async getDistrictName(id) {
      var url = `${this.$Const.API_HOST}/api/v1/Districts/${id}`;
      await axios
        .get(url)
        .then((response) => {
          this.districtName = response.data.data.districtName;
          this.districtId = response.data.data.districtId;
        })
        .catch((err) => {
          console.log(err);
        });
      if (this.store.districtId != null) {
        this.getWard(id);
      }
    },
    /*
     *Call api lấy tên, mã xã phường
     *CreatedBy: ndtin(18/06/2021)
     */
    async getWardName(id) {
      var url = `${this.$Const.API_HOST}/api/v1/Wards/${id}`;
      await axios
        .get(url)
        .then((response) => {
          this.wardName = response.data.data.wardName;
          this.wardId = response.data.data.wardId;
        })
        .catch((err) => {
          console.log(err);
        });
    },
    //đóng cửa sổ
    close() {
      this.$emit("closeTab");
    },
    /*
     * đóng model nếu kiểm tra có dữ liệu thì hiển thị thông báo.
     *CreatedBy: ndtin(21/06/2021)
     */
    closeTapAndSave() {
      if (
        (this.store.storeName != "" && this.store.storeName != null) ||
        (this.store.storeCode != "" && this.store.storeCode != null) ||
        (this.store.address != "" && this.store.address != null) ||
        (this.countryId != "" && this.countryId != null) ||
        (this.store.street != "" && this.store.street != null) ||
        (this.store.storeTaxCode != "" && this.store.storeTaxCode != null)
      ) {
        if (
          (this.editId != null && this.editId != "") ||
          (this.replicationId != null && this.replicationId != "")
        ) {
          this.$emit("closeTab");
        } else {
          this.openTapSaveData();
        }
      } else {
        this.$emit("closeTab");
      }
    },
    //==================Thao tác Combobox Quốc gia==================
    /*
     *Thực hiện hiển thị danh sách quốc gia
     *CreatedBy: ndtin(18/06/2021)
     */
    showDropCountry() {
      this.isActive = !this.isActive;
      this.listItemCountry = this.listCountry;
      document.getElementById("inputCountry").focus();
    },
    /*
     *tìm kiếm quốc gia khi nhập từ khóa
     *CreatedBy: ndtin(18/06/2021)
     */
    onSearchCountry(value) {
      //nếu không có giá trị thì không hiện
      this.countryId = null;
      this.provinceName = null;
      this.provinceId = null;
      this.districtName = null;
      this.districtId = null;
      this.wardName = null;
      this.wardId = null;
      if (value == "") {
        this.isActive = false;
      } else {
        this.listItemCountry = this.listCountry.filter((lists) =>
          lists.countryName.toLowerCase().includes(value.toLowerCase())
        );
        //xử lý
        if (
          this.listItemCountry[0].countryId != "" &&
          this.listItemCountry[0].countryId != null
        ) {
          this.isActive = true;
        } else {
          this.isActive = false;
        }
      }
    },
    /*
     *Lưu lại mã và tên quốc gia khi chọn
     *CreatedBy: ndtin(18/06/2021)
     */
    selectItemCountry(id, name) {
      //lưu lại mã, tên quốc gia
      this.countryName = name;
      this.countryId = id;
      //thực hiện đóng combobox
      this.isActive = !this.isActive;
      //call api lấy danh sách thành phố từ mã quốc gia
      this.getProvince(id);
      //set các giá trị thành phố, quận huyện, xã phường về null khi chọn quốc gia mới
      this.provinceName = null;
      this.provinceId = null;
      this.districtName = null;
      this.districtId = null;
      this.wardName = null;
      this.wardId = null;
      document.getElementById("inputCountry").focus();
    },
    /*
     *call Api lấy danh sách quốc gia
     *CreatedBy: ndtin(18/06/2021)
     */
    async getCountry() {
      var url = `${this.$Const.API_HOST}/api/v1/Countrys`;
      await axios
        .get(url)
        .then((response) => {
          this.listCountry = response.data.data;
        })
        .catch((err) => {
          console.log(err);
        });
    },
    //===========Thao Tác trên combobox Thành phố===============
    /*
     *Tìm kiếm thành phố bằng từ khóa
     *CreatedBy: ndtin(18/06/2021)
     */
    onSearchProvince(value) {
      //nếu không có giá trị thì không hiện
      this.provinceId = null;
      this.districtName = null;
      this.districtId = null;
      this.wardName = null;
      this.wardId = null;
      if (value == "") {
        this.isActiveProvince = false;
      } else {
        this.listItemProvince = this.listProvince.filter((lists) =>
          lists.provinceName.toLowerCase().includes(value.toLowerCase())
        );
        if (
          this.listItemProvince[0].provinceId != "" &&
          this.listItemProvince[0].provinceId != null
        ) {
          this.isActiveProvince = true;
        } else {
          this.isActiveProvince = false;
        }
      }
    },
    /*
     *Hiển thị tất cả thành phố khi click vào button
     *CreatedBy: ndtin(18/06/2021)
     */
    showDropProvince() {
      this.isActiveProvince = !this.isActiveProvince;
      this.listItemProvince = this.listProvince;
      document.getElementById("inputProvince").focus();
    },
    /*
     *Lưu lại mã, tên thành phố khi chọn
     *CreatedBy: ndtin(18/06/2021)
     */
    selectItemProvince(id, name) {
      //lưu lại mã, tên
      this.provinceName = name;
      this.provinceId = id;
      //đóng combobox
      this.isActiveProvince = !this.isActiveProvince;
      //thực hiện call api lấy danh sách quận huyện từ mã thành phố
      this.getDistrict(id);
      //set các giá trị mã, tên quận huyện, xã phường về null khi chọn thành phố mới
      this.districtName = null;
      this.districtId = null;
      this.wardName = null;
      this.wardId = null;
      document.getElementById("inputProvince").focus();
    },
    /*
     *call api lấy danh sách quốc gia
     *CreatedBy: ndtin(18/06/2021)
     */
    async getProvince(id) {
      var url = `${this.$Const.API_HOST}/api/v1/Provinces/GetProvincetWithCountry/${id}`;
      await axios
        .get(url)
        .then((response) => {
          this.listProvince = response.data.data;
        })
        .catch((err) => {
          console.log(err);
        });
    },
    //===========Thao tác trên combobox Quận huyện==========
    /*
     *tìm kiếm quận huyện bằng từ khóa
     *CreatedBy: ndtin(18/06/2021)
     */
    onSearchDistrict(value) {
      this.districtId = null;
      this.wardName = null;
      this.wardId = null;
      //nếu không có giá trị thì không hiện
      if (value == "") {
        this.isActiveDistrict = false;
      } else {
        this.listItemDistrict = this.listDistrict.filter((lists) =>
          lists.districtName.toLowerCase().includes(value.toLowerCase())
        );
        if (
          this.listItemDistrict[0].districtId != "" &&
          this.listItemDistrict[0].districtId != null
        ) {
          this.isActiveDistrict = true;
        } else {
          this.isActiveDistrict = false;
        }
      }
    },
    /*
     *Hiển thị tất cả quận huyện khi click vào button
     *CreatedBy: ndtin(18/06/2021)
     */
    showDropDistrict() {
      this.isActiveDistrict = !this.isActiveDistrict;
      this.listItemDistrict = this.listDistrict;
      document.getElementById("inputDistrict").focus();
    },
    /*
     *lưu lại giá trị tên, mã quận huyện khi chọn
     *CreatedBy: ndtin(18/06/2021)
     */
    selectItemDistrict(id, name) {
      //lưu lại tên, mã
      this.districtName = name;
      this.districtId = id;
      //đóng combobox
      this.isActiveDistrict = !this.isActiveDistrict;
      //lấy danh sách xã phường theo id quận huyện
      this.getWard(id);
      //set giá trị xã phường về null khi chọn quận huyện mới
      this.wardName = null;
      this.wardId = null;
      document.getElementById("inputDistrict").focus();
    },
    /*
     *call api lấy danh sách quận huyện theo id thành phố
     *CreatedBy: ndtin(18/06/2021)
     */
    async getDistrict(id) {
      var url = `${this.$Const.API_HOST}/api/v1/Districts/GetDistrictWithProvince/${id}`;
      await axios
        .get(url)
        .then((response) => {
          this.listDistrict = response.data.data;
        })
        .catch((err) => {
          console.log(err);
        });
    },

    //===========Thao tác xử lý trên combobox Xã phường
    /*
     *Thực hiện tìm kiếm xã phường bằng từ khóa
     *CreatedBy: ndtin(18/06/2021)
     */
    onSearchWard(value) {
      this.wardId = null;
      //nếu không có giá trị thì không hiện
      if (value == "") {
        this.isActiveWard = false;
      } else {
        this.listItemWard = this.listWard.filter((lists) =>
          lists.wardName.toLowerCase().includes(value.toLowerCase())
        );
        if (
          this.listItemWard[0].wardId != "" &&
          this.listItemWard[0].wardId != null
        ) {
          this.isActiveWard = true;
        } else {
          this.isActiveWard = false;
        }
      }
    },
    /*
     * hiển thị tất cả các xã phường trong quận huyện đã chọn
     *CreatedBy: ndtin(18/06/2021)
     */
    showDropWard() {
      this.isActiveWard = !this.isActiveWard;
      this.listItemWard = this.listWard;
      document.getElementById("inputWard").focus();
    },
    /*
     *Lưu lại tên, mã xã phường đã chọn
     *CreatedBy: ndtin(18/06/2021)
     */
    selectItemWard(id, name) {
      //lưu tên, mã
      this.wardName = name;
      this.wardId = id;
      //đóng combobox
      this.isActiveWard = !this.isActiveWard;
      document.getElementById("inputWard").focus();
    },
    /*
     *call api lấy xã, phường theo quận huyện
     *CreatedBy: ndtin(18/06/2021)
     */
    async getWard(id) {
      var url = `${this.$Const.API_HOST}/api/v1/Wards/GetWardWithDistrict/${id}`;
      await axios
        .get(url)
        .then((response) => {
          this.listWard = response.data.data;
        })
        .catch((err) => {
          console.log(err);
        });
    },
    /*
     *đóng tap save và lưu dữ liệu
     *CreatedBy: ndtin(18/06/2021)
     */
    closeTabSave() {
      this.saveStore();
    },
    /*
     *đóng tap waning
     *CreatedBy: ndtin(18/06/2021)
     */
    closeTabWaning() {
      this.$store.commit("showDialogWaning");
    },
    /*
     *đóng tap save data
     *CreatedBy: ndtin(18/06/2021)
     */
    closeTabSaveData() {
      this.$store.commit("showDialogSaveData");
    },
    /*
     *đóng 2 tap (tap saveData và Model StoreDetail)
     *CreatedBy: ndtin(18/06/2021)
     */
    closeTabNoSave() {
      this.closeTabSaveData();
      this.close();
    },
    /*
     *mở tap save data
     *CreatedBy: ndtin(18/06/2021)
     */
    openTapSaveData() {
      this.$store.commit("showDialogSaveData");
    },
    /*
     *mở tap waning
     *CreatedBy: ndtin(18/06/2021)
     */
    openWaning() {
      this.$store.commit("showDialogWaning");
    },
    /*
     *chỉ cho phép nhập số vào ô input
     *CreatedBy: ndtin(18/06/2021)
     */
    validatePhoneNumber(evt) {
      var letter = /^[0-9]+$/;
      if (!evt.match(letter)) {
        this.isActiveErrorPhone = true;
        this.isShowErrorPhone = true;
          setTimeout(() => this.isShowErrorPhone = false, 1500);
      } else {
        this.isActiveErrorPhone = false;
      }
      if (evt == "") {
        this.isActiveErrorPhone = false;
      }
    },
    /*
     *Kiểm tra dữ liệu country đúng chưua
     *CreatedBy: ndtin(18/06/2021)
     */
    checkValueCountry() {
      if (this.countryId == null) {
        if (this.countryName == null || this.countryName == "") {
          this.isActiveErrorCountry = false;
        } else {
          this.isActiveErrorCountry = true;
          this.isShowErrorCountry = true;
          setTimeout(() => this.isShowErrorCountry = false, 1500);
        }
      } else {
        this.isActiveErrorCountry = false;
      }
      if (this.countryId == null) {
        this.countryName = null;
      }
    },
    /*
     *Kiểm tra dữ liệu Province đúng chưua
     *CreatedBy: ndtin(18/06/2021)
     */
    checkValueProvince() {
      if (this.provinceId == null) {
        if (this.provinceName == null || this.provinceName == "") {
          this.isActiveErrorProvince = false;
        } else {
          this.isActiveErrorProvince = true;
          this.isShowErrorProvince = true;
          setTimeout(() => this.isShowErrorProvince = false, 1500);
        }
      } else {
        this.isActiveErrorProvince = false;
      }
      if (this.provinceId == null) {
        this.provinceName = null;
      }
    },
    /*
     *Kiểm tra dữ liệu District đúng chưua
     *CreatedBy: ndtin(18/06/2021)
     */
    checkValueDistrict() {
      if (this.districtId == null) {
        if (this.districtName == null || this.districtName == "") {
          this.isActiveErrorDistrict = false;
        } else {
          this.isActiveErrorDistrict = true;
          this.isShowErrorDistrict = true;
          setTimeout(() => this.isShowErrorDistrict = false, 1500);
        }
      } else {
        this.isActiveErrorDistrict = false;
      }
      if (this.districtId == null) {
        this.districtName = null;
      }
    },
    /*
     *Kiểm tra dữ liệu Ward đúng chưua
     *CreatedBy: ndtin(18/06/2021)
     */
    checkValueWard() {
      if (this.wardId == null) {
        if (this.wardName == null || this.wardName == "") {
          this.isActiveErrorWard = false;
        } else {
          this.isActiveErrorWard = true;
          this.isShowErrorWard = true;
          setTimeout(() => this.isShowErrorWard = false, 1500);
        }
      } else {
        this.isActiveErrorWard = false;
      }
      if (this.wardId == null) {
        this.wardName = null;
      }
    },
  },
  data() {
    return {
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
      //actieve error storeCode
      isActiveError: false,
      isShowErrorStoreCode: false,
      //actieve error storeName
      isActiveErrorStoreName: false,
      isShowErrorStoreName: false,
      //actieve error address
      isActiveErrorAddress: false,
      isShowErrorAddress: false,
      //check code store
      isCodeExits: false,
      //check validate number input
      isActiveErrorPhone: false,
      isShowErrorPhone: false,
      //country error select
      isActiveErrorCountry: false,
      isShowErrorCountry: false,
      //provice errror select
      isActiveErrorProvince: false,
      isShowErrorProvince: false,
      //district error select
      isActiveErrorDistrict: false,
      isShowErrorDistrict: false,
      //Ward error select
      isActiveErrorWard: false,
      isShowErrorWard: false,
      //kiểm tra ng dùng ấn button lưu hay lưu thêm mới
      isSave: false,
      //lấy code cửa hàng lúc đầu
      storeCodeFirst: "",
      isLoadingForm: true,
    };
  },
};
</script>
<style scoped>
@import "../../styles/dictionary/storeDetail.css";
</style>