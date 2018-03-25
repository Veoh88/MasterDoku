package de.mjust.master.model;

import com.mashape.unirest.http.HttpResponse;
import com.mashape.unirest.http.JsonNode;
import com.mashape.unirest.http.exceptions.UnirestException;
import de.mjust.master.provider.IDataProvider;
import de.mjust.master.provider.UnirestHttpProvider;
import elemental.json.JsonObject;
import org.json.JSONArray;
import org.json.JSONObject;

import java.util.*;

public class RestDataSource implements IDataSource {

    private String sourceUri;
    private String sourceName;
    private int updateInterval = 0;
    private IDataProvider dataProvider;
    private Collection<DataObject> dataObjects;

    public RestDataSource(String name, String uri) {
        this.sourceUri = uri;
        this.sourceName = name;
        this.dataProvider = new UnirestHttpProvider();
    }

    @Override
    public String getSourceName() {
        return sourceName;
    }

    @Override
    public String getSourceOrigin() {
        return this.sourceUri;
    }

    @Override
    public void setSourceOrigin(String sourceOrigin) {
        this.sourceUri = sourceOrigin;
    }

    @Override
    public void setDataProvider(IDataProvider provider) {

    }

    @Override
    public void setUpdateInterval(int seconds) {
        this.updateInterval = seconds;
    }

    @Override
    public Collection<DataObject> getDataObjects() {
        try {
            dataObjects = new ArrayList<>();
            HttpResponse<JsonNode> response = this.dataProvider.performHttpGet(this.sourceUri, new HashMap<String, Object>());
            if (response.getBody().isArray()) {
                JSONArray jsonArray = response.getBody().getArray();
                if(jsonArray.length() > 1) {
                    dataObjects = convertArrayToDataObjects(jsonArray);
                    addThisSourceToDataObjects();
                    return dataObjects;
                }
                else{
                    dataObjects = convertSingleArrayToDataObjects(jsonArray);
                    addThisSourceToDataObjects();
                    return dataObjects;
                }
            } else {
                JSONObject jsonObject = response.getBody().getObject();
                dataObjects = parseDataObjectsFromJsonObject(jsonObject);
                addThisSourceToDataObjects();
                return dataObjects;
            }
        } catch (UnirestException e) {
            e.printStackTrace();
        }
        return null;
    }

    private void addThisSourceToDataObjects() {
        for(DataObject dataObject: dataObjects){
            dataObject.setDataSourceOrigin(this);
        }
    }

    private Collection<DataObject> convertArrayToDataObjects(JSONArray jsonArray) {
        HashSet<DataObject> dataObjects = new HashSet<>();
        HashSet<String> dataKeys = new HashSet<>();

        for(Object arrayObject : jsonArray){
            JSONObject jsonObject = (JSONObject) arrayObject;
            Iterator<?> keys = jsonObject.keys();
            while (keys.hasNext()) {
                String key = (String) keys.next();
                dataKeys.add(key);
            }
        }

        for(String key : dataKeys){
            DataObject dataObject = generateDataObject(key, jsonArray);
            dataObjects.add(dataObject);

        }
        return dataObjects;
    }

    private DataObject generateDataObject(String key, JSONArray jsonArray) {

        List<Object> dataObjectValues = new ArrayList<>();
        for(Object arrayObject : jsonArray){
            JSONObject jsonObject = (JSONObject) arrayObject;
            dataObjectValues.add(jsonObject.get(key));
        }
        return new DataObject(key, dataObjectValues);
    }

    private Collection<DataObject> convertSingleArrayToDataObjects(JSONArray jsonArray) {
        HashSet<DataObject> dataObjects = new HashSet<>();
        for (Object arrayObject : jsonArray) {
            dataObjects.addAll(parseDataObjectsFromJsonObject((JSONObject) arrayObject));
        }
        return dataObjects;
    }

    private Set<DataObject> parseDataObjectsFromJsonObject(JSONObject arrayObject) {
        HashSet<DataObject> dataObjects = new HashSet<>();

        JSONObject jsonObject = arrayObject;
        Iterator<?> keys = jsonObject.keys();
        while (keys.hasNext()) {
            String key = (String) keys.next();
            if (jsonObject.get(key) instanceof JSONObject) {

            } else {
                dataObjects.add(new DataObject(key, jsonObject.get(key)));
            }
        }
        return dataObjects;
    }

    public String getSourceUri() {
        return sourceUri;
    }

    public void setSourceUri(String sourceUri) {
        this.sourceUri = sourceUri;
    }
}
