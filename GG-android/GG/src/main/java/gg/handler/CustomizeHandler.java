package gg.handler;

import android.annotation.SuppressLint;

import com.oraycn.es.communicate.framework.ICustomizeHandler;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import gg.example.android_qqfix.ChatApplication;
import gg.model.ChatContentContract;
import gg.model.ContractType;
import gg.model.UserStatusChangedContract;

/**
 * Created by ZN on 2015/9/1.
 */
public class CustomizeHandler implements ICustomizeHandler{

    private ChatApplication app;

    public CustomizeHandler(ChatApplication app) {
        this.app = app;
    }

    @SuppressLint("UseSparseArrays")
    private Map<Integer, List<InformationListener>> chartListenerListMap = new HashMap<Integer, List<InformationListener>>();

    @Override
    public void handleInformation(String sourceUserID, int informationType,byte[] info) {

        ContractType type = ContractType.getContractTypeByCode(informationType);
        try
        {
            switch (type) {
                case CHAT: {
                    ChatContentContract chatContent = new ChatContentContract();
                    chatContent.deserialize(info);
                    app.insertChatInfo(sourceUserID,chatContent);

                    List<InformationListener> list = chartListenerListMap.get(type.getType());
                    if (list != null) {
                        for (InformationListener listener : list) {
                            listener.execute(sourceUserID, chatContent);
                        }
                    }
                    break;
                }
                case OTHERSTATUSCHANGED: {
                    UserStatusChangedContract userStatusChangedContract=new UserStatusChangedContract();
                    userStatusChangedContract.deserialize(info);

                    app.changMyFriendStatus(userStatusChangedContract.getUserID(),userStatusChangedContract.getStatus());
                    break;
                }
                default:
                    break;
            }
        }
        catch(Exception ee)
        {

        }
    }

    @Override
    public byte[] handleQuery(String sourceUserID, int informationType,
                              byte[] info) {
        String resp = app.getEngine().getCurrentUserID() + " 已经处理了"
                + new String(info);

        return resp.getBytes();
    }

    public void addInformationListener(int type, InformationListener listener) {
        List<InformationListener> listenerList = chartListenerListMap.get(type);
        if (listenerList == null) {
            listenerList = new ArrayList<InformationListener>();
        }
        listenerList.add(listener);
        chartListenerListMap.put(type, listenerList);
    }

    public void removeInformationListener(int type, InformationListener listener) {
        List<InformationListener> listenerList = chartListenerListMap.get(type);
        if (listenerList == null) {
            return;
        }
        listenerList.remove(listener);
        chartListenerListMap.put(type, listenerList);
    }

    public interface InformationListener {
        public void execute(String sourceUserID, Object info);
    }
}
