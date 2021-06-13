import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);

const store = new Vuex.Store({
    state: {
        isShowDetail: false,
    },
    mutations: {
        showDetailStore(state){
            state.isShowDetail = !state.isShowDetail;
        },
    },
    actions: {},
    modules: {},
    getters: {
        getIsShow(state){
            return state.isShowDetail;
        },
    },
});

export default store;