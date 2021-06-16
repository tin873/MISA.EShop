import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);

const store = new Vuex.Store({
    state: {
        isShowDetail: false,
        dataRow:{},
        pageSize: 10,
    },
    mutations: {
        showDetailStore(state){
            state.isShowDetail = !state.isShowDetail;
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
        }
    },
});

export default store;