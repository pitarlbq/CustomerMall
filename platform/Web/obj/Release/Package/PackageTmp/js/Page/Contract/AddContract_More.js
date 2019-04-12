$(function () {
});
function saveData() {
    var isValid = ffObj.form('enableValidation').form('validate');
    if (!isValid) {
        return;
    }
    if (parent.ContractID > 0 && ContractID <= 0) {
        ContractID = parent.ContractID;
    }
    parent.MaskUtil.mask('body', '提交中');
    $('#ff').form('submit', {
        url: '../Handler/ContractHandler.ashx',
        onSubmit: function (param) {
            param.visit = 'savecontractmoreinfo';
            param.ContractID = ContractID;
            param.canedit = cansavelog;
        },
        success: function (data) {
            parent.MaskUtil.unmask();
            var dataObj = eval("(" + data + ")");
            if (dataObj.status) {
                if (dataObj.ID > 0) {
                    ContractID = dataObj.ID;
                    parent.ContractID = ContractID;
                    show_message('保存成功', 'success', function () {
                        closeWin();
                    });
                    return;
                }
                show_message("合同记录不存在", "info");
            }
            else if (dataObj.msg) {
                show_message(dataObj.msg, "info");
            }
            else {
                show_message('系统错误', 'error');
            }
        }
    });
}
function closeWin() {
    parent.$("#winadd").window("close");
}
