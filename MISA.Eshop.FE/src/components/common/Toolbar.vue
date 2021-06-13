<template>
    <div class="toolbar">
        <div class="feature-page">
            <button class="icon-toolbar icon-page-first mgr-5"></button>
            <button class="icon-toolbar icon-preview mgr-5"></button>
            <div class="page-name mgr-5">Trang</div>
            <input class="input-toolbar mgr-5" value="1" type="text" />
            <div class="page-name mgr-5">trên 1</div>
            <button class="icon-toolbar icon-next mgr-5"></button>
            <button class="icon-toolbar icon-last mgr-5"></button>
            <button class="icon-toolbar icon-refresh mgr-5"></button>
            <select class="select-toolbar" name="" id="">
                <option>50</option>
                <option>40</option>
                <option>30</option>
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
})
</script>
<style scoped>
@import '../../styles/common/toolbar.css';
</style>
