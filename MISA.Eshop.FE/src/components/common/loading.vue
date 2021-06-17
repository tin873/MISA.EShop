<template>
    <div class="loading">
        <div class="load-background"></div>
        <div class="load">
            <div class="x-mask-loading x-mask-msg-inner">
                <div class="icon-loading"></div>
                <div class="x-mask-msg-text">
                    Đang lấy dữ liệu ...
                </div>
            </div>
        </div>
    </div>
</template>
<script>
export default ({
    name: "loading",
})
</script>
<style scoped>
.loading{
    position: absolute;
    top: 110px;
    left: 10px;
    bottom: 54px;
    right: 10px;
    z-index: 1000;
}
.load-background{
    position: absolute;
    width: 100%;
    height: 100%;
    background-color: black;
    opacity: 0.3;
}
.load{
    position: absolute;
    padding: 10px;
    background: #d0d0d0;
    right: auto;
    left: 805px;
    top: 340.4px;
}
.x-mask-loading{
    padding: 0;
    background-color: transparent;
    color: #404040;
    font: 300 13px open sans,helvetica neue,helvetica,arial,verdana,sans-serif;
}

</style>
