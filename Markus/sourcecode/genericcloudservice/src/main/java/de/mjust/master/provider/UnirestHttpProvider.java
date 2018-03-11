package de.mjust.master.provider;

import com.mashape.unirest.http.HttpResponse;
import com.mashape.unirest.http.JsonNode;
import com.mashape.unirest.http.Unirest;
import com.mashape.unirest.http.exceptions.UnirestException;

import java.util.Map;

public class UnirestHttpProvider implements IDataProvider {

    public HttpResponse<JsonNode> performHttpGet(String uri, Map<String, Object> queryParams) throws UnirestException {
        HttpResponse<JsonNode> response = Unirest.get(uri).queryString(queryParams).asJson();
        return response;
    }
}
