import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);

const store = new Vuex.Store({
    state: {
        isShowDetail: false,
        dataRow:{},
        pageSize: 10,
        isShowDialog: false,
        isLoading: false,
        isShowDialogWaning: false,
        isShowDialogSaveData: false,
    },
    mutations: {
        showDetailStore(state){
            state.isShowDetail = !state.isShowDetail;
        },

        showDialog(state){
            state.isShowDialog = !state.isShowDialog;
        },

        showDialogSaveData(state){
            state.isShowDialogSaveData = !state.isShowDialogSaveData;
        },

        showDialogWaning(state){
            state.isShowDialogWaning = !state.isShowDialogWaning;
        },

        showLoading(state){
            state.isLoading = !state.isLoading;
        },

        setDataRow(state, payload){
            state.dataRow = payload;
        },

        setPageSize(state, payload){
            state.pageSize = payload;
        },
    },
    actions: {},
    modules: {},
    getters: {
        getIsShow(state){
            return state.isShowDetail;
        },

        getDataRow(state){
            return state.dataRow;
        },

        getPageSize(state){
            return state.pageSize;
        },

        getIsShowDialog(state){
            return state.isShowDialog;
        },

        getIsShowDialogSaveData(state){
            return state.isShowDialogSaveData;
        },

        getIsShowDialogWaning(state){
            return state.isShowDialogWaning;
        },

        getIsLoading(state){
            return state.isLoading;
        },
    },
});

export default store;