<template>
  <div class="view-store">
    <div class="header-features">
      <button class="btn add-btn hover-pointer" @click="addStore(false)">
        <div class="icon-header icon-add"></div>
        <div class="item-name-content">Thêm mới</div>
      </button>
      <button
        class="btn btn-borderleft hover-pointer"
        @click="replicationStore"
      >
        <div class="icon-header icon-replic"></div>
        <div class="item-name-content">Nhân bản</div>
      </button>
      <button
        class="btn btn-borderleft hover-pointer"
        @click="editStoreBtn"
        :disabled="rowDataActive.storeId == null"
      >
        <div class="icon-header icon-edit"></div>
        <div class="item-name-content">Sửa</div>
      </button>
      <button
        class="btn btn-borderleft hover-pointer"
        @click="deleteStore"
        :disabled="rowDataActive.storeId == null"
      >
        <div class="icon-header icon-delete"></div>
        <div class="item-name-content">Xóa</div>
      </button>
      <div class="btn btn-borderleft hover-pointer" @click="refresh">
        <div class="icon-header icon-load"></div>
        <div class="item-name-content">Nạp</div>
      </div>
    </div>
    <div class="content-grid">
      <table class="table-asset" id="idtableAsset">
        <colgroup>
          <col width="189" />
          <col width="250" />
          <col width="1000" />
          <col width="155" />
          <col width="155" />
        </colgroup>
        <thead>
          <tr>
            <th>
              <div class="name-col">Mã cửa hàng</div>
              <div class="filter">
                <button class="btn-gird">
                  <span class="text-button">*</span>
                </button>
                <input
                  class="input-filter input-code"
                  type="text"
                  v-model="dataFilter.storeCode"
                  @input="filterStore"
                />
              </div>
            </th>
            <th>
              <div class="name-col">Tên cửa hàng</div>
              <div class="filter">
                <button class="btn-gird">
                  <span class="text-button">*</span>
                </button>
                <input
                  class="input-filter input-name"
                  type="text"
                  v-model="dataFilter.storeName"
                  @input="filterStore"
                />
              </div>
            </th>
            <th>
              <div class="name-col">Địa chỉ</div>
              <div class="filter">
                <button class="btn-gird">
                  <span class="text-button">*</span>
                </button>
                <input
                  class="input-filter input-address"
                  type="text"
                  v-model="dataFilter.address"
                  @input="filterStore"
                />
              </div>
            </th>
            <th>
              <div class="name-col">Số điện thoại</div>
              <div class="filter">
                <button class="btn-gird">
                  <span class="text-button">*</span>
                </button>
                <input
                  class="input-filter input-phone"
                  type="text"
                  v-model="dataFilter.phoneNumber"
                  @input="filterStore"
                />
              </div>
            </th>
            <th>
              <div class="name-col">Trạng thái</div>
              <div class="filter">
                <div class="combobox-model">
                  <input
                    type="text"
                    id="status"
                    v-model="statusName"
                    class="input-custom-cbb width-custom"
                    @input="searchStatus($event.target.value)"
                  />
                  <button
                    class="btn-cbb-status icon-down"
                    @click="showDropStatus"
                  />
                </div>
                <!-- buid item-->
                <div
                  class="flex-item custom-item"
                  :class="{ isActiveCbb: isActive }"
                >
                  <div
                    :class="{ activeItem: item.value == statusId }"
                    v-for="item in listStatusSearch"
                    :key="item.value"
                    class="item-custom"
                    @click="selectItemStatus(item.value, item.status)"
                  >
                    {{ item.status }}
                  </div>
                </div>
              </div>
            </th>
          </tr>
        </thead>
        <tbody>
          <tr
            v-for="stores in listStore"
            :key="stores.storeId"
            :class="{
              isSelectrow:
                rowDataActive.storeId == stores.storeId &&
                rowDataActive.storeId != null,
            }"
            @click="rowClick(stores)"
            @dblclick="editStoreDb(stores)"
          >
            <td>{{ stores.storeCode }}</td>
            <td>{{ stores.storeName }}</td>
            <td>{{ stores.address }}</td>
            <td>{{ stores.phoneNumber }}</td>
            <td>{{ getTextValue(stores.status) }}</td>
          </tr>
          <Loading v-if="isShowLoading" />
        </tbody>
      </table>
      <Toolbar
        :totalPage="totalPage"
        :totalRecord="totalRecord"
        :curentPage="curentPage"
        @pageChanged="GetPagingFilter"
      />
    </div>
    <ComfirmDelete
      @closeDialog="closeDialog"
      v-if="isShowDialog"
      @pageChanged="GetPagingFilter"
      @DeleteStore="DeleteStore"
    />
    <Detail
      @closeTab="closeTab"
      v-if="isShowDetail"
      :titleModel="titleModel"
      @pageChanged="GetPagingFilter"
      :replicationId="replicationId"
      :editId="editId"
      @AddStoreNew="AddStoreNew"
      :isEdit="isEdit"
      @addNewStore="addStore"
    />
  </div>
</template>
<script>
import Toolbar from "../../components/common/BasePaging.vue";
import Detail from "./StoreDetail.vue";
import ComfirmDelete from "../../components/dialog/ComfirmDelete.vue";
import Loading from "../../components/common/BaseLoading.vue";
import axios from "axios";
export default {
  name: "StoreManager",
  components: {
    Toolbar,
    Detail,
    ComfirmDelete,
    Loading,
  },
  created() {
    //tạo 10 bản ghi khi load trang
    this.setPage();
    //thực hiện lấy dữ liệu
    this.onLoadStore();
  },
  computed: {
    /*
     *lấy giá trị hiển thị model
     */
    isShowDetail() {
      return this.$store.getters.getIsShow;
    },
    /*
     *lấy kích thước trang
     */
    pageSize() {
      return this.$store.getters.getPageSize;
    },

    //laays gias trij hien thi dialog delete
    isShowDialog() {
      return this.$store.getters.getIsShowDialog;
    },

    //laays gia tri hien thi loading du lieu
    isShowLoading() {
      return this.$store.getters.getIsLoading;
    },
  },
  methods: {
    /***
     * xóa 1 bản ghi trong danh sách
     * createdBy: ndtin(19/6/2021)
     */
    DeleteStore(valueId) {
      this.listStore = this.listStore.filter(
        (item) => item.storeId !== valueId
      );
    },
    /*
     *Hiển thị dữ liệu vừa lưu mà không load lại trang
     *CreatedBy: ndtin(18/06/2021)
     */
    AddStoreNew(valueStore) {
      if (
        valueStore.storeCode != null &&
        valueStore.storeCode != "" &&
        valueStore.storeName != null &&
        valueStore.storeName != "" &&
        valueStore.address != null &&
        valueStore.address != ""
      ) {
        this.listStore.unshift(valueStore);
        this.listStore.pop();
      }
    },
    //=================Thao tác xử lý cobobbox chọn status
    /*
     *Hiển thị các trạng thái
     *CreatedBy: ndtin(18/06/2021)
     */
    showDropStatus() {
      this.listStatusSearch = this.listStatus;
      this.isActive = !this.isActive;
      document.getElementById("status").focus();
    },
    /*
     *Lưu dữ liệu mã, tên khi chọn trạng thái
     *CreatedBy: ndtin(18/06/2021)
     */
    selectItemStatus(value, name) {
      this.statusId = value;
      this.statusName = name;
      //đóng combobox
      this.isActive = !this.isActive;
      //thực hiện lọc khi chọn
      this.GetPagingFilter(1);
      document.getElementById("status").focus();
    },
    /*
     *Tìm kiếm trạng thái bằng từ khóa
     *CreatedBy: ndtin(18/06/2021)
     */
    searchStatus(value) {
      //nếu không có giá trị thì không hiện
      if (value == "") {
        this.isActive = false;
      } else {
        this.listStatusSearch = this.listStatus.filter((lists) =>
          lists.status.toLowerCase().includes(value.toLowerCase())
        );
        if (this.listStatusSearch != null) {
          this.isActive = true;
        }
      }
    },
    /*
     *lọc thông tin cửa hàng theo mã, tên, số điện thoại, địa chỉ, trạng thái
     *CreatedBy: ndtin(18/06/2021)
     */
    filterStore() {
      this.GetPagingFilter(1);
    },

    /*
     *Hiển thị trạng thái hoạt động theo tiếng việt
     *CreatedBy: ndtin(18/06/2021)
     */
    getTextValue(value) {
      if (value == null) {
        return "";
      }
      if (value) {
        return "Ngừng hoạt động";
      } else {
        return "Đang hoạt động";
      }
    },
    //khi load trang set giá trị pageSize = 10
    setPage() {
      this.$store.commit("setPageSize", 10);
    },
    //load lại trang
    refresh() {
      this.GetPagingFilter(1);
    },
    //chọn dòng
    rowClick(value) {
      this.rowDataActive = value;
    },
    /*
     *Mở cửa xổ thêm mới cửa hàng
     *CreatedBy: ndtin(18/06/2021)
     */
    addStore(value) {
      this.isEdit = false;
      this.replicationId = "";
      this.editId = "";
      this.rowDataEmty = {};
      this.setRowData(this.rowDataEmty);
      this.titleModel = "Thêm mới cửa hàng";
      this.$store.commit("showDetailStore");
      if (value) {
        this.$store.commit("showDetailStore");
      }
    },
    /**
     * check rowDataEmty còn rỗng không
     */
    /*
     *mở aler thông báo xóa
     *CreatedBy: ndtin(18/06/2021)
     */
    deleteStore() {
      this.setRowData(this.rowDataActive);
      this.$store.commit("showDialog");
    },
    /*
     *lưu dữ liệu đã chọn vào store và mở cửa xổ sửa thông tin cửa hàng
     *CreatedBy: ndtin(18/06/2021)
     */
    editStoreDb(value) {
      this.isEdit = true;
      this.replicationId = "";
      this.editId = value.storeId;
      this.titleModel = "Sửa cửa hàng";
      this.setRowData(value);
      this.$store.commit("showDetailStore");
    },
    editStoreBtn() {
      this.isEdit = true;
      this.replicationId = "";
      this.editId = this.rowDataActive.storeId;
      this.titleModel = "Sửa cửa hàng";
      this.setRowData(this.rowDataActive);
      this.$store.commit("showDetailStore");
    },
    /*
     *lưu dữ liệu đã chọn vào store và mở cửa xổ thêm mới cửa hàng
     *CreatedBy: ndtin(18/06/2021)
     */
    replicationStore() {
      this.isEdit = false;
      this.editId = "";
      this.replicationId = this.rowDataActive.storeId;
      this.setRowData(this.rowDataActive);
      this.titleModel = "Thêm mới cửa hàng";
      this.$store.commit("showDetailStore");
    },
    //lưu dữ liệu dòng đã chọn trên store
    setRowData(data) {
      this.$store.commit("setDataRow", data);
    },
    //đóng cửa xổ thêm, sửa, nhân bản
    closeTab() {
      this.$store.commit("showDetailStore");
    },
    //đóng dialog thông báo xóa
    closeDialog() {
      this.$store.commit("showDialog");
    },
    /*
     *call api lọc thông tin cửa hàng
     *CreatedBy: ndtin(18/06/2021)
     */
    async filterMyStore() {
      let value = this.dataFilter;
      //khởi tạo giá trị chuỗi filter
      let stringStoreName = "";
      let stringAddress = "";
      let stringPhoneNumber = "";
      let stringStatus = "";
      let stringStoreCode =
        value.storeCode != "" ? `storeCode=${value.storeCode}` : "";
      if (value.storeCode != "") {
        stringStoreName =
          value.storeName != "" ? `&storeName=${value.storeName}` : "";
      } else {
        stringStoreName =
          value.storeName != "" ? `storeName=${value.storeName}` : "";
      }
      if (value.storeCode != "" || value.storeName != "") {
        stringAddress = value.address != "" ? `&address=${value.address}` : "";
      } else {
        stringAddress = value.address != "" ? `address=${value.address}` : "";
      }
      if (
        value.storeCode != "" ||
        value.storeName != "" ||
        value.address != ""
      ) {
        stringPhoneNumber =
          value.phoneNumber != "" ? `&phoneNumber=${value.phoneNumber}` : "";
      } else {
        stringPhoneNumber =
          value.phoneNumber != "" ? `phoneNumber=${value.phoneNumber}` : "";
      }
      if (
        value.storeCode != "" ||
        value.storeName != "" ||
        value.address != "" ||
        value.phoneNumber != ""
      ) {
        stringStatus = this.statusId >= 0 ? `&status=${this.statusId}` : "";
      } else {
        stringStatus = this.statusId >= 0 ? `status=${this.statusId}` : "";
      }
      var url = `${this.$Const.API_HOST}/api/v1/Stores/filter?${stringStoreCode}${stringStoreName}${stringAddress}${stringPhoneNumber}${stringStatus}`;
      this.$store.commit("showLoading");
      await axios
        .get(url)
        .then((response) => {
          this.listStore = response.data.data;
          this.$store.commit("showLoading");
        })
        .catch((err) => {
          console.log(err);
        });
      this.rowDataActive = this.listStore[0];
    },
    /**
     * lọc và phân trang
     * CreatedBy: ndtin(22/06/2021)
     */
    async GetPagingFilter(page) {
      let value = this.dataFilter;
      var pageIndex = page;
      this.curentPage = page;
      this.$store.commit("showLoading");
      value = this.dataFilter;
      //khởi tạo giá trị chuỗi filter
      let stringStoreName = "";
      let stringAddress = "";
      let stringPhoneNumber = "";
      let stringStatus = "";
      let stringPageIndex = "";
      let stringPageSize = "";
      let stringStoreCode =
        value.storeCode != "" ? `storeCode=${value.storeCode}` : "";
      if (value.storeCode != "") {
        stringStoreName =
          value.storeName != "" ? `&storeName=${value.storeName}` : "";
      } else {
        stringStoreName =
          value.storeName != "" ? `storeName=${value.storeName}` : "";
      }
      if (value.storeCode != "" || value.storeName != "") {
        stringAddress = value.address != "" ? `&address=${value.address}` : "";
      } else {
        stringAddress = value.address != "" ? `address=${value.address}` : "";
      }
      if (
        value.storeCode != "" ||
        value.storeName != "" ||
        value.address != ""
      ) {
        stringPhoneNumber =
          value.phoneNumber != "" ? `&phoneNumber=${value.phoneNumber}` : "";
      } else {
        stringPhoneNumber =
          value.phoneNumber != "" ? `phoneNumber=${value.phoneNumber}` : "";
      }
      if (
        value.storeCode != "" ||
        value.storeName != "" ||
        value.address != "" ||
        value.phoneNumber != ""
      ) {
        stringStatus = this.statusId >= 0 ? `&status=${this.statusId}` : "";
      } else {
        stringStatus = this.statusId >= 0 ? `status=${this.statusId}` : "";
      }
      if (
        value.storeCode != "" ||
        value.storeName != "" ||
        value.address != "" ||
        value.phoneNumber != "" ||
        this.statusId != -1
      ) {
        stringPageSize = `&pageSize=${this.pageSize}`;
      } else {
        stringPageSize = `pageSize=${this.pageSize}`;
      }
      stringPageIndex = `&pageIndex=${pageIndex}`;
      var url = `${this.$Const.API_HOST}/api/v1/Stores/filterPaging?${stringStoreCode}${stringStoreName}${stringAddress}${stringPhoneNumber}${stringStatus}${stringPageSize}${stringPageIndex}`;
      console.log(url);
      await axios
        .get(url)
        .then((response) => {
          this.listStore = response.data.data;
          this.totalPage = response.data.totalPage;
          this.totalRecord = response.data.totalRecord;
          this.$store.commit("showLoading");
        })
        .catch((err) => {
          console.log(err);
        });
      this.rowDataActive = this.listStore[0];
    },
    /*
     * call api lấy thông tin cửa hàng phân trang
     *creaedBy: ndtin(19/6/2021)
     */
    async onPageChange(page) {
      var pageIndex = page;
      this.curentPage = page;
      //hieenr thi loading
      this.$store.commit("showLoading");
      var url = `${this.$Const.API_HOST}/api/v1/Stores/Paging?pageSize=${this.pageSize}&pageIndex=${pageIndex}`;
      await axios
        .get(url)
        .then((response) => {
          this.listStore = response.data.data;
          this.totalPage = response.data.totalPage;
          this.totalRecord = response.data.totalRecord;
          this.$store.commit("showLoading");
        })
        .catch((err) => {
          console.log(err);
        });
      this.rowDataActive = this.listStore[0];
    },
    /*
     * load thông tin cửa hàng khi vào trang
     */
    onLoadStore() {
      this.GetPagingFilter(1);
    },
  },
  data() {
    return {
      //danh sách cửa hàng
      listStore: [],
      //cửa hàng đang trỏ vào
      rowDataActive: {},
      //set empty khi thêm mới cửa hàng
      rowDataEmty: {},
      //khởi tạo thông tin lọc cửa hàng
      dataFilter: {
        storeCode: "",
        storeName: "",
        address: "",
        phoneNumber: "",
      },
      //tổng trang
      totalPage: 0,
      //tổng bản ghi
      totalRecord: 0,
      //trang đang xem
      curentPage: 1,
      titleModel: "",
      //kiểm tra người dùng click vào form sửa thông tin hay không
      isEdit: false,
      //lấy id khi nhân bản
      replicationId: "",
      //lấy id khi sửa
      editId: "",
      listStatus: [
        {
          value: -1,
          status: "Tất cả",
        },
        {
          value: 0,
          status: "Đang hoạt động",
        },
        {
          value: 1,
          status: "Ngừng hoạt động",
        },
      ],
      statusName: "Tất cả",
      statusId: -1,
      isActive: false,
      listStatusSearch: [],
    };
  },
};
</script>
<style scoped>
@import "../../styles/dictionary/storeManagerment.css";
</style>
