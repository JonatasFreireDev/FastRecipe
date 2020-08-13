import React from 'react';

import { StackScreenProps } from '@react-navigation/stack';
import { View, Text, Button } from 'react-native';
import { MyProfileStack } from '../../../interface/IRoutes';

const Favorites: React.FC<StackScreenProps<MyProfileStack, 'Favorites'>> = ({
  navigation,
}) => {
  return (
    <>
      <View style={{ flex: 1, justifyContent: 'center', alignItems: 'center' }}>
        <Text> Favorites</Text>
      </View>
    </>
  );
};

export default Favorites;
