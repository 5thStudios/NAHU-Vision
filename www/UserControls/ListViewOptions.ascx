<%@ Control Language="vb" AutoEventWireup="false" CodeFile="ListViewOptions.ascx.vb" EnableViewState="false" Inherits="ListViewOptions" %>



<%--<div class="listViews">
    <input id="rbGrid" type="radio" name="viewType" value="grid" class="">
    <label for="rbGrid" class="rbGridView"><span></span> &nbsp;&nbsp;GRID VIEW</label>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <input id="rbList" type="radio" name="viewType" value="list" class="" checked="checked">
    <label for="rbList" class="rbListView"><span></span> &nbsp;&nbsp;LIST VIEW</label>
</div>--%>



<div class="listViews row">
    <div class="small-12 medium-12 large-12 columns">
        <input id="rbGrid" type="radio" name="viewType" value="grid" class="">
        <label for="rbGrid" class="rbGridView"><span></span>&nbsp;&nbsp;GRID VIEW</label>
    </div>
    <div class="small-12 medium-12 large-12 columns end">
        <input id="rbList" type="radio" name="viewType" value="list" class="" checked="checked">
        <label for="rbList" class="rbListView"><span></span>&nbsp;&nbsp;LIST VIEW</label>
    </div>
</div>