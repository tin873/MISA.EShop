<template>
    <div class="modal">
        <div class="modal-background"></div>
        <div class="modal-content">
            <div class="modal-header">
                <div class="header-title">Thêm mới cửa hàng</div>
                <div class="icon-modal icon-close" @click="close()"></div>
            </div>
            <div class="modal-body">
                <div class="modal-item">
                    <div class="modal-item-name">Mã cửa hàng<span>*</span></div>
                    <div class="model-item-input">
                        <input class="validate-input mgr-5" type="text"/>
                        <div class="icon-error isActive"></div>
                    </div>
                </div>
                <div class="modal-item">
                    <div class="modal-item-name">Tên cửa hàng<span>*</span></div>
                    <div class="model-item-input">
                        <input class="validate-input mgr-5" type="text"/>
                        <div class="icon-error isActive"></div>
                    </div>
                </div>
                <div class="modal-item-special">
                    <div class="modal-item-name">Địa chỉ<span>*</span></div>
                    <div class="model-item-input">
                        <textarea class="validate-textarea mgr-5" type="text"/>
                        <div class="icon-error isActive"></div>
                    </div>
                </div>
                <div class="modal-item">
                    <div class="double-item">
                        <div class="modal-item-name">Số điện thoại</div>
                        <input class="validate-input-sort mgr-5" type="text"/>
                    </div>
                    <div class="double-item">
                        <div class="modal-item-name">Mã số thuế</div>
                        <input class="validate-input-sort mgr-5" type="text"/>
                    </div>
                </div>
                <div class="modal-item">
                    <div class="double-item">
                        <div class="modal-item-name">Quốc gia</div>
                        <select class="mgr-5 model-select hover-pointer" name="" id="">
                            <option value="1" >Việt Nam</option>
                        </select>
                    </div>
                </div>
                <div class="modal-item">
                    <div class="double-item">
                        <div class="modal-item-name">Tỉnh/Thành phố</div>
                        <select class="mgr-5 model-select hover-pointer" name="" id="">
                            <option value="1" >Hà Nội</option>
                        </select>
                    </div>
                    <div class="double-item">
                        <div class="modal-item-name">Quận/Huyện</div>
                        <select class="mgr-5 model-select hover-pointer" name="" id="">
                            <option value="1" >Đan Phượng</option>
                        </select>
                    </div>
                </div>
                <div class="modal-item">
                    <div class="double-item">
                        <div class="modal-item-name">Phường/Xã</div>
                        <select class="mgr-5 model-select hover-pointer" name="" id="">
                            <option value="1" >Tân lập</option>
                        </select>
                    </div>
                    <div class="double-item">
                        <div class="modal-item-name">Đường Phố</div>
                        <input class="validate-input-sort mgr-5" type="text"/>
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
                    <button class="btn-footer-add-save mgr-8 hover-pointer">
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
export default ({
    name: 'StoreDetail',
    methods: {
        close(){
            console.log("1");
            this.$emit('closeTab');
        },
    }
})
</script>

<style scoped>
@import '../../styles/dictionary/storeDetail.css';
</style>
