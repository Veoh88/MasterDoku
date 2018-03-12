package de.mjust.master.provider;

import com.mashape.unirest.http.HttpResponse;
import com.mashape.unirest.http.JsonNode;
import com.mashape.unirest.http.exceptions.UnirestException;

import java.util.Map;

public interface IDataProvider {

    HttpResponse<JsonNode> performHttpGet(String uri, Map<String, Object> queryparams) throws UnirestException;
}
