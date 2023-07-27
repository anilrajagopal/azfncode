module.exports = async function (context, myBlob) {
    context.bindings.outputBlob = context.bindings.myBlob;
    context.log("JavaScript blob trigger function processed blob \n Blob:", context.bindingData.blobTrigger, "\n Blob Size:", myBlob.length, "Bytes");
};
